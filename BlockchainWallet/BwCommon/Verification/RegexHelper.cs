using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BwCommon.Verification
{
    public static class RegexHelper
    {
        private static readonly List<string> _regexBeautifulNumberHelper = new List<string>();
        static RegexHelper()
        {
            ////匹配6位顺增  
            // pattern = @"(?:0(?=1)|1(?=2)|2(?=3)|3(?=4)|4(?=5)|5(?=6)|6(?=7)|7(?=8)|8(?=9)){5}\d";
            //_regexBeautifulNumberHelper.Add(pattern);
            ////匹配6位顺降  
            //pattern = @"(?:9(?=8)|8(?=7)|7(?=6)|6(?=5)|5(?=4)|4(?=3)|3(?=2)|2(?=1)|1(?=0)){5}\d";
            //_regexBeautifulNumberHelper.Add(pattern);
            ////匹配6位顺增或顺降  
            //pattern = @"(?:(?:0(?=1)|1(?=2)|2(?=3)|3(?=4)|4(?=5)|5(?=6)|6(?=7)|7(?=8)|8(?=9)){5}|(?:9(?=8)|8(?=7)|7(?=6)|6(?=5)|5(?=4)|4(?=3)|3(?=2)|2(?=1)|1(?=0)){5})\d";
            //_regexBeautifulNumberHelper.Add(pattern);
            //匹配4-9位连续的数字  
            string pattern = @"(?:(?:0(?=1)|1(?=2)|2(?=3)|3(?=4)|4(?=5)|5(?=6)|6(?=7)|7(?=8)|8(?=9)){3,}|(?:9(?=8)|8(?=7)|7(?=6)|6(?=5)|5(?=4)|4(?=3)|3(?=2)|2(?=1)|1(?=0)){3,})\d";
            _regexBeautifulNumberHelper.Add(pattern);
            //匹配3位以上的重复数字  
            pattern = @"([\d])\1{2,}";
            _regexBeautifulNumberHelper.Add(pattern);
            //匹配手机号码类  
            pattern = @"(13[0-9]|15[0-9]|18[0-9])([\d]{2,4}){2}";
            _regexBeautifulNumberHelper.Add(pattern);
            //匹配2233类型  
            pattern = @"([\d])\1{1,}([\d])\2{1,}";
            _regexBeautifulNumberHelper.Add(pattern);
        }

        public static bool CheckBeautifulNumber(string checkContent)
        {
            foreach (var str in _regexBeautifulNumberHelper)
            {
                Regex regex = new Regex(str);
                if (regex.IsMatch(checkContent))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
