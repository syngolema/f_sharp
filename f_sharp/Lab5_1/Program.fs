// Learn more about F# at http://fsharp.org

open System

let rec fib num = 
        match num with 
        | 0 -> 0
        | 1 -> 1
        | x -> fib (x-1) + fib (x-2)

let rec factorial num = 
        match num with
        | 0 -> 1
        | x -> factorial(x-1) * x

[<EntryPoint>]
let main argv =
    let myCoolNumber = 15;
    printfn "%dth number in Fibonacci sequence is %d" myCoolNumber (fib 15);
    printfn "%d factorial is %d" myCoolNumber (factorial 5);
    ignore (System.Console.ReadLine());
    0

