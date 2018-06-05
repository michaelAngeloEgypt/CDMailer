using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public static class MyExtensions
    {
        /// <summary>
        /// https://stackoverflow.com/questions/1120198/most-efficient-way-to-remove-special-characters-from-string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;
            return Regex.Replace(str, @"[^a-zA-Z0-9_\^\$\.,=]+", "", RegexOptions.Compiled);
        }

        /// <summary>
        /// exact letters and symbols, ignoring letter case but still spaces matter
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool VerySimilarTo(this string x, string y)
        {
            if (String.IsNullOrEmpty(x))
                return String.IsNullOrEmpty(y);

            return x.Equals(y, StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool SimilarTo(this string x, string y)
        {
            if (String.IsNullOrEmpty(x))
                return String.IsNullOrEmpty(y);

            return x.ToCanonicalForm().Equals(y.ToCanonicalForm(), StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// set to lower case and ignore anything other than digits and letters.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ToCanonicalForm(this string x)
        {
            if (String.IsNullOrWhiteSpace(x)) return x;

            char[] arr = x.ToLowerInvariant().ToCharArray();
            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c))));   // || char.IsWhiteSpace(c) || c == '-'
            return new string(arr);

            //return x.ToLowerInvariant().Replace(" ", "");
        }
        /// <summary>
        /// useful for Excel ranges
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ToAlphabetChar(this int src)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int idx = src - 1 >= 26 ? 0 : src - 1 % 26;
            return alpha[idx].ToString();
        }

        /// <summary>
        /// Get string value between [first] a and [last] b.
        /// </summary>
        public static string Between(this string value, string a, string b)
        {
            /*
            int posA = value.IndexOf(a);
            int posB = value.LastIndexOf(b);
            if (posA == -1)
            {
                return "";
            }
            if (posB == -1)
            {
                return "";
            }
            int adjustedPosA = posA + a.Length;
            if (adjustedPosA >= posB)
            {
                return "";
            }
            return value.Substring(adjustedPosA, posB - adjustedPosA);
            */

            if (String.IsNullOrEmpty(value))
                return "";

            int start = value.IndexOf(a) + a.Length;
            if (value.StartsWith(a)) start++;
            int end = value.IndexOf(b, start);
            if (end == -1) return "";
            string result = value.Substring(start, end - start);
            return result;
        }

        public static bool MatchesString(this string examinedValue, string referenceValue)
        {
            //use it for huawei PassLHSFilters
            if (String.IsNullOrWhiteSpace(examinedValue) && !String.IsNullOrWhiteSpace(referenceValue)
                || !String.IsNullOrWhiteSpace(examinedValue) && String.IsNullOrWhiteSpace(referenceValue))
                return false;

            if (String.IsNullOrWhiteSpace(examinedValue) && String.IsNullOrWhiteSpace(referenceValue))
                return true;

            return examinedValue.Trim().Equals(referenceValue.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }
        public static bool ContainsString(this string examinedValue, string referenceValue)
        {
            if (String.IsNullOrWhiteSpace(examinedValue) && !String.IsNullOrWhiteSpace(referenceValue)
                || !String.IsNullOrWhiteSpace(examinedValue) && String.IsNullOrWhiteSpace(referenceValue))
                return false;

            if (String.IsNullOrEmpty(examinedValue) && String.IsNullOrEmpty(referenceValue))
                return false;

            return examinedValue.Contains(referenceValue, StringComparison.InvariantCultureIgnoreCase);
        }
        /// <summary>
        /// case-insensitive string.contains
        /// http://stackoverflow.com/questions/444798/case-insensitive-containsstring
        /// http://ppetrov.wordpress.com/2008/06/27/useful-method-6-of-n-ignore-case-on-stringcontains/
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// <see cref="http://stackoverflow.com/questions/10485903/regex-extract-value-from-the-string-between-delimiters"/>
        /// <see cref="http://stackoverflow.com/questions/378415/how-do-i-extract-text-that-lies-between-parentheses-round-brackets"/>
        /// <seealso cref="https://regex101.com"/>
        /// </summary>
        /// <param name="source"></param>
        /// <param name="startDelimiter"></param>
        /// <param name="endDelimiter"></param>
        /// <param name="includeDelimiters"></param>
        /// <returns></returns>
        public static string ExtractStringBetweenDelimiters(this string source, string startDelimiter, string endDelimiter, bool includeDelimiters = true)
        {
            if (String.IsNullOrWhiteSpace(source))
                return String.Empty;

            string victim = Regex.Match(source, String.Format(@"{0}(.*?){1}", startDelimiter, endDelimiter)).Value;

            if (!includeDelimiters)
                victim = victim.Between(startDelimiter, endDelimiter);

            return victim;
        }


        /// <summary>
        /// http://stackoverflow.com/questions/876473/is-there-a-way-to-check-if-a-file-is-in-use
        /// </summary>
        /// <returns></returns>
        public static bool IsFileLocked(this string filename)
        {
            if (!File.Exists(filename))
                return false;

            FileInfo file = new FileInfo(filename);
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool DeleteFile(this string filename)
        {
            try
            {
                if (!File.Exists(filename))
                    return true;

                if (filename.IsFileLocked())
                    return false;

                File.Delete(filename);
                string strCmdText;
                //strCmdText = String.Concat("DEL ", newReport);
                strCmdText = String.Format("/c sdelete -p 1 -s -z -q -a '{0}'", filename);
                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo("CMD.exe", strCmdText);
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                p.StartInfo = psi;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #region reflection
        //
        /// <summary>
        /// used for downcasting
        /// http://stackoverflow.com/questions/988658/unable-to-cast-from-parent-class-to-child-class
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="src"></param>
        public static void CopyProperties(this object src, object dst)
        {
            PropertyInfo[] srcProperties = src.GetType().GetProperties();
            dynamic dstType = dst.GetType();

            if (srcProperties == null | dstType.GetProperties() == null)
            {
                return;
            }

            foreach (PropertyInfo srcProperty in srcProperties)
            {
                PropertyInfo dstProperty = dstType.GetProperty(srcProperty.Name);

                if (dstProperty != null)
                {
                    if (dstProperty.PropertyType.IsAssignableFrom(srcProperty.PropertyType) == true)
                    {
                        dstProperty.SetValue(dst, srcProperty.GetValue(src, null), null);
                    }
                }
            }
        }
        /// <summary>
        /// return the value of constants
        /// usage: typeof(Lookups.GoLiveDatesWorkbook.ColumnNames).GetConstantsValues();
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<String> GetConstantsValues(this Type type)
        {
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.FlattenHierarchy);

            return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).Select(fi => fi.GetValue(type) as String).ToList<String>();
        }
        /// <summary>
        /// Get property value based on its name
        /// http://www.java2s.com/Code/CSharp/Reflection/Getapropertyvaluegivenitsname.htm
        /// </summary>
        /// <param name="srcObj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static Object GetPropertyValue(this object srcObj, string propertyName)
        {

            PropertyInfo propInfoObj = srcObj.GetType().GetProperty(propertyName);

            if (propInfoObj == null)
                return null;

            // Get the value from property.
            object srcValue = srcObj
                      .GetType()
                      .InvokeMember(propInfoObj.Name,
                              BindingFlags.GetProperty,
                              null,
                              srcObj,
                              null);

            return srcValue;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcObj"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static string GetPropertyStringValue(this object srcObj, string propertyName)
        {
            try
            {
                object value = GetPropertyValue(srcObj, propertyName);
                if (value == null)
                    return String.Empty;
                else
                    return value.ToString();

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// var propertyName = GetPropertyName(() => myObject.AProperty); // returns "AProperty"
        /// http://stackoverflow.com/questions/3661824/get-string-name-of-property-using-reflection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(this Expression<Func<T>> propertyExpression)
        {
            return (propertyExpression.Body as MemberExpression).Member.Name;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcObj"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static bool GetPropertyNames(this object srcObj, List<string> properties)
        {
            properties = new List<string>();

            try
            {
                PropertyInfo[] srcProperties = srcObj.GetType().GetProperties();

                if (srcProperties == null)
                    return false;

                foreach (PropertyInfo srcProperty in srcProperties)
                    properties.Add(srcProperty.Name);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// http://stackoverflow.com/questions/7718792/can-i-set-a-property-value-with-reflection
        /// </summary>
        /// <param name="srcObj"></param>
        /// <param name="propName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object srcObj, string propName, Object value)
        {
            var property = srcObj.GetType().GetProperty(propName);
            if (property != null)
                property.SetValue(srcObj, value, null);
        }


        /// <summary>
        /// <see cref="https://stackoverflow.com/questions/1718863/how-to-iterate-all-public-string-properties-in-a-net-class"/>
        /// </summary>
        /// <param name="srcObj"></param>
        /// <returns></returns>
        public static string[] GetPublicStringPropertiesNames(this object srcObj)
        {
            return srcObj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => pi.Name)
                .ToArray();
        }


        public static void DoFunctionOnStringProperties(this Object srcObj, Func<string, string> func)
        {
            var myStringProps = srcObj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.PropertyType == typeof(string) && pi.GetSetMethod() != null)
                .Select(pi => pi);

            foreach (var prop in myStringProps)
            {
                prop.SetValue(srcObj, func(prop.GetValue(srcObj) as string));
            }
        }

        public static void DoFunctionOnSomeStringProperties(this Object srcObj, List<string> propNames, Func<string, string> func)
        {
            if (propNames == null || propNames.Count == 0)
                return;

            var myStringProps = srcObj.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(pi => pi.PropertyType == typeof(string) && pi.GetSetMethod() != null && propNames.Contains(pi.Name))
                .Select(pi => pi);

            foreach (var prop in myStringProps)
            {
                prop.SetValue(srcObj, func(prop.GetValue(srcObj) as string));
            }
        }

        //
        #endregion reflection
    }
}
