using Invoices.Exceptions;
using Invoices.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Invoices.Infrastructure;

//Združuje funkcie na spracovanie rôznych výnimiek. Pridáva buď neznáme výnimky, alebo neplatný stav modelu.
//Pre každý typ výnimky sa definuje akcia na spracovanie výnimky, ktorá zahŕňa výstup HTTP stavového kódu
//a informácie o probléme v tele odpovede.Kód tiež zapisuje informácie o výnimke do knižnice Serilog pre ďalšie spracovanie.
public class ApiExceptionFiltersAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionFilters;

    public ApiExceptionFiltersAttribute()
    {
        _exceptionFilters = new Dictionary<Type, Action<ExceptionContext>>
        {
            {typeof(NoItemException), HandleNoItemException },
            {typeof(TextsException), HandleTextsException },
        };
    }

    //vyvolanie funkcie HandleException pre spracovanie výnimky.Funkcia HandleException slúži
    //na určenie správneho typu výnimky a vyvolanie príslušnej funkcie na jej spracovanie.
    //Metóda OnException sa zavolá vždy, keď je v aplikácii vygenerovaná výnimka.
    //Táto metóda je súčasťou rozhrania ExceptionFilterAttribute, ktoré slúži na zachytenie výnimiek
    //počas behu aplikácie a ich spracovanie. Metóda OnException je volaná pri každom výskyte výnimky
    //a táto implementácia v tejto triede ju využíva na volanie funkcie HandleException na spracovanie výnimky.
    public override void OnException(ExceptionContext context)
    {
        //ExceptionContext predstavuje kontext pre aktuálnu výnimku vyvolanú počas behu aplikácie.
        //Poskytuje informácie o výnimke, ako je typ, hlásenie a stavový objekt, a umožňuje vývojárom definovať
        //akciu na spracovanie tejto výnimky. V rámci ExceptionContext môžu byť výnimky akéhokoľvek typu,
        //ktorý je odvodený od System.Exception. V tomto konkrétnom príklade sú kontrolované dva typy
        //výnimiek: NoItemException a TextsException. Ak je vygenerovaná iná výnimka, ktorá nie je zahrnutá
        //v zozname výnimiek, bude volaná funkcia HandleUnknownException na spracovanie neznámej výnimky.
        HandleException(context);

        //Volanie base.OnException() v tomto prípade slúži na volanie rovnakého metódu v predkovskej triede
        //(predkovskej implementácie).To umožňuje dedenie od tejto triedy a prekrytie funkcie výnimky, pričom
        //umožňuje zachovať pôvodnú implementáciu základnej triedy.V tejto konkrétnej implementácii môže
        //base.OnException() slúžiť napríklad na vykonanie ďalších akcií alebo na spracovanie výnimky iným spôsobom.
        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Log.Error(context.Exception, "Handling exception:");

        //Táto časť kódu zisťuje typ výnimky, ktorá sa stala, z objektu context.Exception.Týmto získava informácie
        //o tom, akého typu výnimka bola vygenerovaná, aby sa na nej následne mohlo vykonať vhodné spracovanie.
        Type type = context.Exception.GetType();

        //Tento if-statement kontroluje, či v slovníku _exceptionFilters obsahuje kľúč pre typ výnimky, ktorá bola vyvolaná.
        //Ak áno, volá sa príslušná akcia, ktorá bola priradená k tomuto typu výnimky.Ak nie, prejde sa na ďalšie
        //spracovanie výnimky.
        if (_exceptionFilters.ContainsKey(type))
        {
//            Toto je zápis pre prístup do slovníka(dictionary) _exceptionFilters.Hranaté zátvorky slúžia na získanie
//            hodnoty priradenej ku kľúču, ktorý je typu Type a reprezentuje typ výnimky.

//V tomto prípade, hodnotou pre daný kľúč typu výnimky bude funkcia, ktorá bude slúžiť na spracovanie výnimky.
//Funkcia bude vyvolaná pomocou Invoke metódy.
            _exceptionFilters[type].Invoke(context);
            return;
        }

        if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
            return;
        }

        HandleUnknownException(context);
    }

    private void HandleUnknownException(ExceptionContext context)
    {
        ProblemDetails details = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }

    private void HandleInvalidModelStateException(ExceptionContext context)
    {
        ValidationProblemDetails details = new ValidationProblemDetails(context.ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandleNoItemException(ExceptionContext context)
    {
        NoItemException exception = context.Exception as NoItemException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);

        context.ExceptionHandled = true;
    }

    private void HandleTextsException(ExceptionContext context)
    {
        //Tento zápis používa operátor "as" na konvertovanie typu výnimky v "ExceptionContext" do typu
        //"NoItemException".Ak sa konverzia nezdarí, vráti sa hodnota "null".
        TextsException exception = context.Exception as TextsException;

        ProblemDetails details = new ProblemDetails()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource already exists.",
            Detail = exception.Message
        };

        context.Result = new NotFoundObjectResult(details);

        context.ExceptionHandled = true;
    }
}
