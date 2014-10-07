
using ProjectStatusTracker.Domain;
using ProjectStatusTracker.Web.Infrastructure;
using StructureMap;
namespace ProjectStatusTracker.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                          x.For<IProjectDataSource>().HttpContextScoped().Use<ProjectDb>();
                        });
            return ObjectFactory.Container;
        }
    }
}