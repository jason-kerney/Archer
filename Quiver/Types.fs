namespace Archer.Quiver

open Microsoft.VisualStudio.TestPlatform.ObjectModel
open Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter
open Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging

[<FileExtension ".dll">]
[<FileExtension ".exe">]
[<DefaultExecutorUri "executor://Archer.Quiver.Executor">]
type QuiverDiscoverer () =
    interface ITestDiscoverer with
        member _.DiscoverTests (containers: string seq, discoveryContext: IDiscoveryContext, logger: IMessageLogger, discoverySink: ITestCaseDiscoverySink) = failwith "todo"
        
[<ExtensionUri "executor://Archer.Quiver.Executor">]
type QuiverExecutor () =
    interface ITestExecutor with
        member this.RunTests (tests: System.Collections.Generic.IEnumerable<TestCase>, runContext: IRunContext, frameworkHandle: IFrameworkHandle): unit = failwith "todo"
        member this.Cancel () = failwith "todo"
        member this.RunTests (sources: System.Collections.Generic.IEnumerable<string>, runContext: IRunContext, frameworkHandle: IFrameworkHandle): unit = failwith "todo"
