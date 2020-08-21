using System;
using System.Reflection;

namespace AGAT.LocoDispatcher.Parser.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}