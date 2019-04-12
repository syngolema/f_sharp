// Learn more about F# at http://fsharp.org

open System

type Decimal private (nominator: int, denominator: int) =
    member this.Nominator = nominator;
    member this.Denominator = denominator;
    static member (+) (decimal1: Decimal, decimal2: Decimal) = 
        Decimal((decimal1.Nominator * decimal2.Denominator + decimal2.Nominator * decimal1.Denominator), decimal1.Denominator * decimal2.Denominator)

    static member (-) (decimal1: Decimal, decimal2: Decimal) = 
        Decimal((decimal1.Nominator * decimal2.Denominator - decimal2.Nominator * decimal1.Denominator), decimal1.Denominator * decimal2.Denominator)

    static member (*) (decimal1: Decimal, decimal2: Decimal) = 
        Decimal(decimal1.Nominator * decimal2.Nominator, decimal1.Denominator * decimal2.Denominator)

    static member (/) (decimal1: Decimal, decimal2: Decimal) = 
        if decimal2.Nominator = 0 then failwith "Cannot divide by 0"
        Decimal(decimal1.Nominator * decimal2.Denominator, decimal1.Denominator * decimal2.Nominator)
    
    static member create(nominator: int, denominator: int): Decimal =
        if denominator = 0 then failwith "Decimal denominator cannot be 0";
        Decimal(nominator, denominator)

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let dec1 = Decimal.create(3, 5);
    let dec2 = Decimal.create(3, 6);
    let sumResult = dec1 + dec2;
    let multiplicationResult = dec1 * dec2;
    let divisionResult = dec1 / dec2;
    let substractionResult = dec1 - dec2;
    printfn "Sum result is %d/%d" sumResult.Nominator sumResult.Denominator
    printfn "Multiplication result is %d/%d" multiplicationResult.Nominator multiplicationResult.Denominator
    printfn "Division result is %d/%d" divisionResult.Nominator divisionResult.Denominator
    printfn "Substraction result is %d/%d" substractionResult.Nominator substractionResult.Denominator
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
