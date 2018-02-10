﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CDMailer.BLL
{
    public static class MyExtensions
    {
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
        //
        #endregion reflection
    }
}