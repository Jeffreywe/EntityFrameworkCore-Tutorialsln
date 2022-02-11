using System;

namespace EntityFrameworkCore_Tutorial {
    /// <summary>
    /// This class to Entity Framework, when you do this you have to add software manually, and it doesnt give
    /// us access to SQL database have to enable that by adding packages in
    /// to find, tools, nuget package manager, manage nuget packages for solution, to add the packages 
    /// go to browse and look for specified pakcages, in this case we want the Microsoft.Entity.FrameworkCore packages, .tools and .sqlserver
    /// have to match up package version numbers with .net uses, in our case .Net5, verify installed properly with correct version numbers,
    /// when installing the packages make suree they go into the correct project with the correct .net version, can remove or update packages in the sltn explorer on projects
    /// to reference classes in folders in the project you have to use the namespace and .foldername to access them
    /// 
    /// </summary>
    class Program {
        static void Main(string[] args) {
        }
    }
}
