namespace Archer.Types

open System
open System.ComponentModel
open Archer.Results

type TestCancelEventArgs (cancel: bool, result: TestResult option) =
    inherit CancelEventArgs (cancel)
    
    new () = TestCancelEventArgs (false, None)
    new (result: TestResult option) = TestCancelEventArgs (false, result)
    new (result: TestResult) = TestCancelEventArgs (false, Some result)
    new (cancel: bool, result: TestResult) = TestCancelEventArgs (cancel, Some result)
    
    member _.TestResult with get () = result
    
type TestEventArgs (result: TestResult option) =
    inherit EventArgs()
    
    new () = TestEventArgs None
    new (result: TestResult) = TestEventArgs (Some result)
    
    member _.TestResult with get () = result

type CancelDelegate = delegate of obj * TestCancelEventArgs -> unit
type Delegate = delegate of obj * TestEventArgs -> unit

and ITest =
    [<CLIEvent>]
    abstract member StartExecution: IEvent<CancelDelegate, TestCancelEventArgs> with get
    
    [<CLIEvent>]
    abstract member StartSetup: IEvent<CancelDelegate, TestCancelEventArgs> with get
    [<CLIEvent>]
    abstract member EndSetup: IEvent<CancelDelegate, TestCancelEventArgs> with get
    
    [<CLIEvent>]
    abstract member StartTest: IEvent<CancelDelegate, TestCancelEventArgs> with get
    [<CLIEvent>]
    abstract member EndTest: IEvent<CancelDelegate, TestCancelEventArgs> with get
    
    [<CLIEvent>]
    abstract member StartTearDown: IEvent<CancelDelegate, TestCancelEventArgs> with get
    [<CLIEvent>]
    abstract member EndTearDown: IEvent<Delegate, TestEventArgs> with get
    
    [<CLIEvent>]
    abstract member EndExecution: IEvent<Delegate, TestEventArgs> with get
    
    abstract member ContainerFullName: string with get
    abstract member ContainerName: string with get
    abstract member TestFullName: string with get
    abstract member TestName: string with get
    
type TestTiming = {
    Setup: TimeSpan
    Test: TimeSpan
    TearDown: TimeSpan
    Total: TimeSpan
}
    
type TestFailureReport = {
    Result: TestResult
    Time: TestTiming
    Test: ITest
}

type TestSuccessReport = {
    Time: TestTiming
    Test: ITest
}
    
type TestContainerReport = {
    ContainerFullName: string
    ContainerName: string
    Failures: TestFailureReport list
    Successes: TestSuccessReport list
}

type TestReport = {
    Seed: int
    TestContainers: TestContainerReport list
}