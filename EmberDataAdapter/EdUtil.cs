using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmberDataAdapter
{
    public static class EdUtil
    {
        public static string ToEdCase(string identifier)
        {
            // Property names in Ember Data are of the format word_word_word
            var sb = new StringBuilder(identifier.Length);
            var propertyNameChars = identifier.ToCharArray();
            bool previousUnderscore = false;

            for (int i = 0; i < identifier.Length; i++)
            {
                char c = propertyNameChars[i];
                if (Char.IsUpper(c))
                {
                    if (i > 0 && !previousUnderscore)
                    {
                        sb.Append('_');
                    }
                    sb.Append(char.ToLower(c));
                    previousUnderscore = false;
                }
                else if (c == '_' && !previousUnderscore)
                {
                    sb.Append('_');
                    previousUnderscore = true;
                }
                else
                {
                    sb.Append(c);
                    previousUnderscore = false;
                }
            }

            return sb.ToString();
        }
    }
}
