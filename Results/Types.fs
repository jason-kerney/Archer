namespace Archer.Results

type Failure =
    | VerificationFailure of string
    | ExceptionFailure of exn
    | GeneralFailure of string
    | SetupFailure of string
    | CancelFailure
    | IgnoredFailure
    | TearDownFailure of string
    | FailureWithMessage of string * Failure
    | CombinationFailure of Failure * Failure
    
type TestResult =
    | TestSuccess
    | TestFailure of Failure