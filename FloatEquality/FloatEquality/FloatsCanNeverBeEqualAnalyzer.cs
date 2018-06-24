using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace FloatEquality
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class FloatsCanNeverBeEqualAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "FloatEquality";
        private const string Title = "Should not compare two floating point numbers directly.";
        private const string MessageFormat = "Due to the way they are stored, two floating-points numbers can have unexpected impercievable rounding errors and so may not be equal even if they seem so. Consider comparing their difference to an epsilon. More Info: https://bit.ly/floating-point-math";
        private const string Description = "Don't compare two floating-point numbers for equality directly.";
        private const string Category = "Usage";

        private static readonly DiagnosticDescriptor _rule =
            new DiagnosticDescriptor(
                DiagnosticId,
                Title,
                MessageFormat,
                Category,
                DiagnosticSeverity.Warning,
                helpLinkUri: "https://bit.ly/floating-point-math",
                isEnabledByDefault: true,
                description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(_rule); } }

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.EqualsExpression);
        }

        private void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var binaryExpression = (BinaryExpressionSyntax)context.Node;

            var left = context.SemanticModel.GetTypeInfo(binaryExpression.Left);
            var right = context.SemanticModel.GetTypeInfo(binaryExpression.Right);

            if (IsFloatingPointNumber(left) && IsFloatingPointNumber(right))
            {
                context.ReportDiagnostic(Diagnostic.Create(_rule, context.Node.GetLocation()));
            }
        }

        private bool IsFloatingPointNumber(TypeInfo type)
        {
            return type.ConvertedType.Name == nameof(Double) || type.ConvertedType.Name == nameof(Single);
        }
    }
}
