namespace Archer.Quiver

open Microsoft.VisualStudio.TestPlatform.ObjectModel
open Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter
open Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging

type Thing2 () =
    member _.GetStuff (tc: TestCase) =
        let id = tc.Id
        let readOnly_Properties = tc.Properties
        let source = tc.Source
        let readOnly_traits = tc.Traits
        let displayName = tc.DisplayName
        let executorUri = tc.ExecutorUri
        let LineNumber = tc.LineNumber
        let codeFilePath = tc.CodeFilePath
        let fullQualifiedName = tc.FullyQualifiedName
        let localExtensionData = tc.LocalExtensionData
        tc.
        
        ()
        


[<FileExtension ".dll">]
[<FileExtension ".exe">]
type Thing () =
    interface ITestDiscoverer with
        member _.DiscoverTests (containers: string seq, discoveryContext: IDiscoveryContext, logger: IMessageLogger, discoverySink: ITestCaseDiscoverySink) = ()