// Learn more about F# at http://fsharp.org

open System
open System

type Complex private (real: float, imaginary: float) = 
    member this.Real = real;
    member this.Imaginary = imaginary;

    static member (+) (complex1: Complex, complex2: Complex) = 
        Complex(complex1.Real + complex2.Real, complex1.Imaginary + complex1.Imaginary)

    static member (-) (complex1: Complex, complex2: Complex) = 
        Complex(complex1.Real - complex2.Real, complex1.Imaginary - complex1.Imaginary)

    static member (*) (complex1: Complex, complex2: Complex) = 
        Complex(complex1.Real * complex2.Real - complex1.Imaginary * complex2.Imaginary, complex1.Real * complex2.Imaginary + complex1.Imaginary * complex2.Real) 

    static member (/) (complex1: Complex, complex2: Complex) = 
        if complex2.Real = 0.0 && complex2.Imaginary = 0.0 then failwith "Cannot divide by 0"
        Complex((complex1.Real * complex2.Real + complex1.Imaginary * complex2.Imaginary) / complex2.Real * complex2.Real + complex2.Imaginary * complex2.Imaginary, 
        (complex1.Imaginary * complex2.Real - complex1.Real * complex2.Imaginary) / complex2.Real * complex2.Real + complex2.Imaginary * complex2.Imaginary)

    static member create(real: float, imaginary: float) =
        new Complex(real, imaginary)
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let complex1 = Complex.create(3.1, 5.2);
    let complex2 = Complex.create(3.3, 6.1);
    let sumResult = complex1 + complex2;
    let multiplicationResult = complex1 * complex2;
    let divisionResult = complex1 / complex2;
    let substractionResult = complex1 - complex2;
    printfn "Sum result is %.2f %.2fi" sumResult.Real sumResult.Imaginary
    printfn "Multiplication result is %f %fi" multiplicationResult.Real multiplicationResult.Imaginary
    printfn "Division result is %f %fi" divisionResult.Real divisionResult.Imaginary
    printfn "Substraction result is %f %fi" substractionResult.Real substractionResult.Imaginary
    System.Console.ReadLine() |> ignore
    0 // return an integer exit code
