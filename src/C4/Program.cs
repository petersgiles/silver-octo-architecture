using System;
using System.Linq;
using System.Reflection;
using Structurizr.Analysis;
using Structurizr.Api;
using System.IO;
using Structurizr;
using Structurizr.Documentation;
using Structurizr.IO.PlantUML;
using System.Threading;

namespace structurizr
{

    /// <summary>
    /// This is a simple example of how to get started with Structurizr for .NET.
    /// </summary>
    class Program
    {
        private const string AssemblyLocation = @"\bin";

        private const long WorkspaceId = 37836;
        private const string ApiKey = "a67721a6-7967-4b71-91ee-bea8bab9d1c5";
        private const string ApiSecret = "8b133d55-4064-4e7c-a180-8cdc2449694d";

        private const string ExternalTag = "External";
        private const string InternalTag = "Internal";

    



        static Boolean serve = false;


        static void Main(string[] args)
        {
            if (args.Length > 0) serve = true;

            // a Structurizr workspace is the wrapper for a software architecture model, views and documentation
            var workspace = new Workspace("Digital Suite", "A software architecture model of the Digital Suite Platform.");
            var model = workspace.Model;
            var views = workspace.Views;
            var styles = views.Configuration.Styles;

            // PEOPLE
            var vip = model.AddPerson("V-VIP", "A very imporatant person. i.e. a Minister, Secretary, or Chief of Staff");
            var vipsupportstaff = model.AddPerson("VIP Support", "A staff member supporting a VIP.");
            var packowner = model.AddPerson("Pack Owner", "Responsible owners and suppliers of digital content for a given subject.");
            var businessadministrator = model.AddPerson("Business Administrators", "Responsible for creating and archiving digital content.");
            var departmentalofficers = model.AddPerson("Departmental Officers", "Responsible for creating and approving digital content.");


            var opssupport = model.AddPerson("Systems Support", "Responsible for the continuing running of the system");
            var anaylstProgrammer = model.AddPerson("Analyst Programmer", "Responsible for the development and delivery of working software changes");


            // SYSTEMS
            var dsuiteSystem = model.AddSoftwareSystem("Digital Suite", "Allows users to view and update briefs, report, and create digitally delivered information for very important people.");

            var provisioning = model.AddSoftwareSystem("Provisoning", "Allows users to provision workspaces for provisioning activities.");


            var sharePointSystem = model.AddSoftwareSystem("SharePoint", "Collaboration Platform");
            var couchDbSystem = model.AddSoftwareSystem("CouchDB", "Data Replication Platform");
            var mobileIronSystem = model.AddSoftwareSystem("Mobile Iron", "Enterprise Mobile Device Management");
            var continuousIntegrationSystem = model.AddSoftwareSystem("Continuous Integration", "Enterprise System Change and Support");
            var configurationSystem = model.AddSoftwareSystem("Desired State Config", "Enterprise System State Integrity");

            dsuiteSystem.Uses(couchDbSystem, "Replicates");
            dsuiteSystem.Uses(sharePointSystem, "Replicates");

            configurationSystem.Uses(sharePointSystem, "Ensures");

            Array.ForEach(
                new[] { dsuiteSystem, mobileIronSystem, couchDbSystem, configurationSystem, sharePointSystem }, 
                p => continuousIntegrationSystem.Uses(p, "Change")
            );

            //CONTAINERS
            var collaboration = dsuiteSystem.AddContainer("Collaboration", "Collaboration", "Client-side web/office application");
            var offlineMobileApp = dsuiteSystem.AddContainer("Mobile Reader", "Reader", "Client-side mobile application");
            var offlineWebApp = dsuiteSystem.AddContainer("Browser Reader", "Reader", "Client-side web application");
            var admintool = dsuiteSystem.AddContainer("Administration", "Administration", "Client-side web application");
            var reporting = dsuiteSystem.AddContainer("Reports", "Reporting", "Server-side web application");

            var notificationServices = dsuiteSystem.AddContainer("Notification", "Notification", "Microservice");
            var subscriptionServices = dsuiteSystem.AddContainer("Subscription", "Subscription", "Microservice");
            var auditSoftwareServices = dsuiteSystem.AddContainer("Audit", "Audit", "Microservice");
            var businessIntelligenceServices = dsuiteSystem.AddContainer("Business Intelligence", "Business Intelligence", "Microservice");

            // PEOPLE SYSTEMS
            opssupport.Uses(mobileIronSystem, "Admin");
            anaylstProgrammer.Uses(continuousIntegrationSystem, "Publishes");

            Array.ForEach(
                new[] { dsuiteSystem, mobileIronSystem },
                p => vip.Uses(p, "Uses")
            );

            vipsupportstaff.Uses(dsuiteSystem, "Uses");
            packowner.Uses(dsuiteSystem, "Uses");
            businessadministrator.Uses(dsuiteSystem, "Uses");
            departmentalofficers.Uses(dsuiteSystem, "Uses");

            packowner.Uses(sharePointSystem, "Uses");
            businessadministrator.Uses(sharePointSystem, "Uses");
            departmentalofficers.Uses(sharePointSystem, "Uses");

            // PEOPLE COMPONENTS
            vip.Uses(offlineMobileApp, "Uses");

            packowner.Uses(admintool, "Uses");

            businessadministrator.Uses(reporting, "Uses");

            vipsupportstaff.Uses(offlineWebApp, "Uses");

            Array.ForEach(
                new[] { collaboration, offlineWebApp },
                p => departmentalofficers.Uses(p, "Uses")
            );

            Array.ForEach(
                new[] { notificationServices, subscriptionServices, auditSoftwareServices , businessIntelligenceServices },
                p => admintool.Uses(p, "Uses")
            );

            Array.ForEach(
                new[] { notificationServices, subscriptionServices, auditSoftwareServices, businessIntelligenceServices },
                p => collaboration.Uses(p, "Uses")
            );


            offlineMobileApp.Uses(auditSoftwareServices, "Uses");
            offlineWebApp.Uses(auditSoftwareServices, "Uses");

            Array.ForEach(
                 new[] { auditSoftwareServices, businessIntelligenceServices },
                 p => reporting.Uses(p, "Uses")
            );


            var buildtime = $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
            // VIEWS
            var enterpriseView = views.CreateSystemContextView(dsuiteSystem, "Digital Suite Enterprise View", buildtime);
            enterpriseView.PaperSize = PaperSize.A3_Landscape;
            Array.ForEach(new[] { vip, vipsupportstaff, packowner , businessadministrator ,departmentalofficers }, p => enterpriseView.Add(p));
            enterpriseView.Add(dsuiteSystem);

            var systemView = views.CreateSystemContextView(dsuiteSystem, "Digital Suite System View", buildtime);
            systemView.PaperSize = PaperSize.A3_Landscape;
            systemView.AddAllSoftwareSystems();
            systemView.AddAllPeople();
            systemView.AddAllElements();

            var contextView = views.CreateContainerView(dsuiteSystem, "Digital Suite Container View", buildtime);
            contextView.PaperSize = PaperSize.A3_Landscape;
            //contextView.AddAllSoftwareSystems();
            Array.ForEach(new[] { vip, vipsupportstaff, packowner, businessadministrator, departmentalofficers }, p => contextView.Add(p));
            contextView.AddAllContainers();

            var componentView = views.CreateContainerView(dsuiteSystem, "Digital Suite Component View", buildtime);
            componentView.PaperSize = PaperSize.A3_Landscape;


            var deploymentView = views.CreateContainerView(dsuiteSystem, "Digital Suite Deployment View", buildtime);
            deploymentView.PaperSize = PaperSize.A3_Landscape;

            // add some documentation
            StructurizrDocumentationTemplate template = new StructurizrDocumentationTemplate(workspace);
            template.AddContextSection(dsuiteSystem, Format.Markdown,
                "Here is some context about the software system...\n" +
                "\n" +
                "![](embed:SystemContext)");

            // add some styling
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });

           // UploadWorkspaceToStructurizr(workspace);
            WriteWorkspace(workspace);
            //Console.ReadLine();
        }

        private static void WriteWorkspace(Workspace workspace)
        {
            var basedir = AppDomain.CurrentDomain.BaseDirectory;

            using (StreamWriter stringWriter = new System.IO.StreamWriter(Path.Combine(basedir, "c4.wsd")))
            {
                PlantUMLWriter plantUMLWriter = new PlantUMLWriter();
                plantUMLWriter.Write(workspace, stringWriter);
            }

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.WorkingDirectory = basedir;
                process.StartInfo.FileName = "plantuml";
                process.StartInfo.Arguments = "-tsvg *.wsd -o .\\Content\\docs\\svg";
                process.Start();
                process.WaitForExit();
            }

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.WorkingDirectory = Path.Combine(basedir, "Content");
                process.StartInfo.FileName = "mkdocs";
                process.StartInfo.Arguments = "build";
                process.Start();
                process.WaitForExit();
            }

            if (!serve) return;

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.WorkingDirectory = Path.Combine(basedir, "Content");
                process.StartInfo.FileName = "mkdocs";
                process.StartInfo.Arguments = "serve";
                process.Start();
            }

            Thread.Sleep(2000);

            using (System.Diagnostics.Process process = new System.Diagnostics.Process())
            {
                process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.Verb = "open";
                process.StartInfo.FileName = "http://localhost:8000";
                process.Start();
            }


        }

        private static void UploadWorkspaceToStructurizr(Workspace workspace)
        {
            StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
            structurizrClient.PutWorkspace(WorkspaceId, workspace);
        }

    }
}

//static void Main(string[] args)
//{
//    Workspace workspace = new Workspace("Contoso University", "A software architecture model of the Contoso University sample project.");
//    Model model = workspace.Model;
//    ViewSet views = workspace.Views;
//    Styles styles = views.Configuration.Styles;

//    Person universityStaff = model.AddPerson("University Staff", "A staff member of the Contoso University.");
//    SoftwareSystem contosoUniversity = model.AddSoftwareSystem("Contoso University", "Allows staff to view and update student, course, and instructor information.");
//    universityStaff.Uses(contosoUniversity, "uses");

//    // if the client-side of this application was richer (e.g. it was a single-page app), I would include the web browser
//    // as a container (i.e. User --uses-> Web Browser --uses-> Web Application (backend for frontend) --uses-> Database)
//    Container webApplication = contosoUniversity.AddContainer("Web Application", "Allows staff to view and update student, course, and instructor information.", "Microsoft ASP.NET MVC");
//    Container database = contosoUniversity.AddContainer("Database", "Stores information about students, courses and instructors", "Microsoft SQL Server Express LocalDB");
//    database.AddTags("Database");
//    universityStaff.Uses(webApplication, "Uses", "HTTPS");
//    webApplication.Uses(database, "Reads from and writes to");

//    DirectoryInfo directory = new DirectoryInfo(AssemblyLocation);
//    foreach (FileInfo file in directory.EnumerateFiles())
//    {
//        if (file.Extension == ".dll")
//        {
//            Assembly.LoadFrom(file.FullName);
//        }
//    }

//    Type iController = Assembly.LoadFrom(Path.Combine(AssemblyLocation, "System.Web.Mvc.dll")).GetType("System.Web.Mvc.IController");
//    Type dbContext = Assembly.LoadFrom(Path.Combine(AssemblyLocation, "EntityFramework.dll")).GetType("System.Data.Entity.DbContext");

//    //TypeMatcherComponentFinderStrategy typeMatcherComponentFinderStrategy = new TypeMatcherComponentFinderStrategy(
//    //    new InterfaceImplementationTypeMatcher(iController, null, "ASP.NET MVC Controller"),
//    //    new ExtendsClassTypeMatcher(dbContext, null, "Entity Framework DbContext")
//    //);
//    //typeMatcherComponentFinderStrategy.AddSupportingTypesStrategy(new ReferencedTypesSupportingTypesStrategy(false));

//    //ComponentFinder componentFinder = new ComponentFinder(
//    //    webApplication,
//    //    "ContosoUniversity",
//    //    typeMatcherComponentFinderStrategy
//    ////new TypeSummaryComponentFinderStrategy(@"C:\Users\simon\ContosoUniversity\ContosoUniversity.sln", "ContosoUniversity")
//    //);
//    //componentFinder.FindComponents();

//    // connect the user to the web MVC controllers
//    webApplication.Components.ToList().FindAll(c => c.Technology == "ASP.NET MVC Controller").ForEach(c => universityStaff.Uses(c, "uses"));

//    // connect all DbContext components to the database
//    webApplication.Components.ToList().FindAll(c => c.Technology == "Entity Framework DbContext").ForEach(c => c.Uses(database, "Reads from and writes to"));

//    // link the components to the source code
//    foreach (Component component in webApplication.Components)
//    {
//        foreach (CodeElement codeElement in component.CodeElements)
//        {
//            if (codeElement.Url != null)
//            {
//                codeElement.Url = codeElement.Url.Replace(new Uri(@"C:\Users\simon\ContosoUniversity\").AbsoluteUri, "https://github.com/simonbrowndotje/ContosoUniversity/blob/master/");
//                codeElement.Url = codeElement.Url.Replace('\\', '/');
//            }
//        }
//    }

//    // rather than creating a component model for the database, let's simply link to the DDL
//    // (this is really just an example of linking an arbitrary element in the model to an external resource)
//    database.Url = "https://github.com/simonbrowndotje/ContosoUniversity/tree/master/ContosoUniversity/Migrations";

//    SystemContextView contextView = views.CreateSystemContextView(contosoUniversity, "Context", "The system context view for the Contoso University system.");
//    contextView.AddAllElements();

//    ContainerView containerView = views.CreateContainerView(contosoUniversity, "Containers", "The containers that make up the Contoso University system.");
//    containerView.AddAllElements();

//    ComponentView componentView = views.CreateComponentView(webApplication, "Components", "The components inside the Contoso University web application.");
//    componentView.AddAllElements();

//    // create an example dynamic view for a feature
//    DynamicView dynamicView = views.CreateDynamicView(webApplication, "GetCoursesForDepartment", "A summary of the \"get courses for department\" feature.");
//    Component courseController = webApplication.GetComponentWithName("CourseController");
//    Component schoolContext = webApplication.GetComponentWithName("SchoolContext");
//    dynamicView.Add(universityStaff, "Requests the list of courses from", courseController);
//    dynamicView.Add(courseController, "Uses", schoolContext);
//    dynamicView.Add(schoolContext, "Gets a list of courses from", database);

//    // add some styling
//    styles.Add(new ElementStyle(Tags.Person) { Background = "#0d4d4d", Color = "#ffffff", Shape = Shape.Person });
//    styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#003333", Color = "#ffffff" });
//    styles.Add(new ElementStyle(Tags.Container) { Background = "#226666", Color = "#ffffff" });
//    styles.Add(new ElementStyle("Database") { Shape = Shape.Cylinder });
//    styles.Add(new ElementStyle(Tags.Component) { Background = "#407f7f", Color = "#ffffff" });

//    StructurizrClient structurizrClient = new StructurizrClient(ApiKey, ApiSecret);
//    structurizrClient.PutWorkspace(WorkspaceId, workspace);
//}