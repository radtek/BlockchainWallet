using System;
using System.Text;

namespace BwDal.Helper
{
    public static class SqlHelper
    {
        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereEqual(string columnName, object value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.Equal, ref stringBuilder);
        }

        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereGreater(string columnName, object value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.Greater, ref stringBuilder);
        }

        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereLess(string columnName, object value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.Less, ref stringBuilder);
        }

        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereIn(string columnName, object value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.In, ref stringBuilder);
        }

        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereLike(string columnName, string value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.Like, ref stringBuilder);
        }
        /// <summary>
        /// 自动拼接Where条件
        /// </summary>
        /// <param name="columnName">字段名</param>
        /// <param name="value">值</param>
        /// <param name="stringBuilder">父字符串</param>
        public static void AppendAndWhereUnEqual(string columnName, string value, ref StringBuilder stringBuilder)
        {
            GetWhere(LinkType.And, columnName, value, LogicalOperatorType.UnEqual, ref stringBuilder);
        }

        public static void GetWhere(LinkType linkType, string columnName, object value, LogicalOperatorType logicalOperatorType, ref StringBuilder stringBuilder)
        {
            switch (value.GetType().Name)
            {
                case "String":
                case "DateTime":
                    stringBuilder.Append(linkType.GetLinkStr() + columnName + logicalOperatorType.GetLogicalOperatorStr() + "'" + value + "'" + logicalOperatorType.LogicalOperatorAppend() + linkType.LinkAppend());
                    break;
                case "Double":
                case "Decimal":
                case "Single":
                    stringBuilder.Append(linkType.GetLinkStr() + columnName + logicalOperatorType.GetLogicalOperatorStr() + value + logicalOperatorType.LogicalOperatorAppend() + linkType.LinkAppend());
                    break;
            }
        }

        private static string GetLogicalOperatorStr(this LogicalOperatorType logicalOperatorType)
        {
            switch (logicalOperatorType)
            {
                case LogicalOperatorType.Equal:
                    return " = ";
                case LogicalOperatorType.Greater:
                    return " > ";
                case LogicalOperatorType.Less:
                    return " < ";
                case LogicalOperatorType.UnEqual:
                    return " != ";
                case LogicalOperatorType.Like:
                    return " LIKE '%";
                case LogicalOperatorType.In:
                    return " IN (";
                default:
                    throw new ArgumentOutOfRangeException("logicalOperatorType", logicalOperatorType, null);
            }
        }

        private static string LogicalOperatorAppend(this LogicalOperatorType logicalOperatorType)
        {
            switch (logicalOperatorType)
            {
                case LogicalOperatorType.Equal:
                    return "";
                case LogicalOperatorType.Greater:
                    return "";
                case LogicalOperatorType.Less:
                    return "";
                case LogicalOperatorType.UnEqual:
                    return "";
                case LogicalOperatorType.Like:
                    return "%";
                case LogicalOperatorType.In:
                    return ")";
                default:
                    throw new ArgumentOutOfRangeException("logicalOperatorType", logicalOperatorType, null);
            }
        }

        private static string LinkAppend(this LinkType linkType)
        {
            switch (linkType)
            {
                case LinkType.And:
                    return "";
                case LinkType.Exisit:
                    return " )";
                case LinkType.UnExisit:
                    return " )";
                default:
                    throw new ArgumentOutOfRangeException("linkType", linkType, null);
            }
        }

        private static string GetLinkStr(this LinkType linkType)
        {
            switch (linkType)
            {
                case LinkType.And:
                    return " AND ";
                case LinkType.Exisit:
                    return " EXISIT( ";
                case LinkType.UnExisit:
                    return " UN EXISIT( ";
                default:
                    throw new ArgumentOutOfRangeException("linkType", linkType, null);
            }
        }

        public static string LimitString(this DataPagingModelGet dataPagingModelGet)
        {
            return string.Format(" LIMIT {0},{1};SELECT FOUND_ROWS(); ", dataPagingModelGet.StartSize, dataPagingModelGet.PageCount);
        }
    }

    /// <summary>
    /// 连接类型
    /// </summary>
    public enum LinkType
    {
        And,
        Exisit,
        UnExisit
    }
    /// <summary>
    /// 逻辑连接符
    /// </summary>
    public enum LogicalOperatorType
    {
        /// <summary>
        /// =
        /// </summary>
        Equal,
        /// <summary>
        /// >
        /// </summary>
        Greater,
        /// <summary>
        /// <
        /// </summary>
        Less,
        /// <summary>
        /// !=
        /// </summary>
        UnEqual,
        /// <summary>
        /// Like
        /// </summary>
        Like,
        /// <summary>
        /// in
        /// </summary>
        In
    }
}
