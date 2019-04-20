using System;
using System.Activities;
using System.ComponentModel;

namespace NumberToWords.Activities
{
    /// <summary>
    /// Converts a number to it's spelled string version.
    /// </summary>
    [Description("Converts a number to it's spelled string version.")]
    public class NumberToWords : CodeActivity
    {
        [Category("Input")]
        [Description("The input number (Integer).")]
        [RequiredArgument]
        [OverloadGroup("Int")]
        InArgument<int> IntNumber { get; set; }

        [Category("Input")]
        [Description("The input number (Long).")]
        [RequiredArgument]
        [OverloadGroup("Long")]
        InArgument<long> LongNumber { get; set; }

        [Category("Input")]
        [Description("The input number (String).")]
        [RequiredArgument]
        [OverloadGroup("String")]
        InArgument<string> StringNumber { get; set; }

        [Category("Output")]
        [Description("The spelled in number.")]
        [RequiredArgument]
        OutArgument<string> SpelledInNumber { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string numberString = string.Empty;
            if (IntNumber.Expression != null)
                numberString = IntNumber.Get(context).ToString();
            else if (LongNumber.Expression != null)
                numberString = LongNumber.Get(context).ToString();
            else if (StringNumber.Expression != null)
                numberString = StringNumber.Get(context).ToString();
            else
                throw new ArgumentException("No input argument was filled.");
            
            string converted = NumberConversor.Convert(numberString);
            SpelledInNumber.Set(context, converted);
        }
    }
}