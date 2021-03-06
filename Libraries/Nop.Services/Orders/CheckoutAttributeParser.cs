using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using Nop.Core.Domain.Orders;

namespace Nop.Services.Orders
{
    /// <summary>
    /// Checkout attribute parser
    /// </summary>
    public partial class CheckoutAttributeParser : ICheckoutAttributeParser
    {
        private readonly ICheckoutAttributeService _checkoutAttributeService;

        public CheckoutAttributeParser(ICheckoutAttributeService checkoutAttributeService)
        {
            this._checkoutAttributeService = checkoutAttributeService;
        }

        /// <summary>
        /// Gets selected checkout attribute identifiers
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected checkout attribute identifiers</returns>
        protected virtual IList<int> ParseCheckoutAttributeIds(string attributesXml)
        {
            var ids = new List<int>();
            if (String.IsNullOrEmpty(attributesXml))
                return ids;

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(attributesXml);

                foreach (XmlNode node in xmlDoc.SelectNodes(@"//Attributes/CheckoutAttribute"))
                {
                    if (node.Attributes != null && node.Attributes["ID"] != null)
                    {
                        string str1 = node.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            ids.Add(id);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
            return ids;
        }

        /// <summary>
        /// Gets selected checkout attributes
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Selected checkout attributes</returns>
        public virtual IList<CheckoutAttribute> ParseCheckoutAttributes(string attributesXml)
        {
            var result = new List<CheckoutAttribute>();
            var ids = ParseCheckoutAttributeIds(attributesXml);
            foreach (int id in ids)
            {
                var attribute = _checkoutAttributeService.GetCheckoutAttributeById(id);
                if (attribute != null)
                {
                    result.Add(attribute);
                }
            }
            return result;
        }

        /// <summary>
        /// Get checkout attribute values
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <returns>Checkout attribute values</returns>
        public virtual IList<CheckoutAttributeValue> ParseCheckoutAttributeValues(string attributesXml)
        {
            var values = new List<CheckoutAttributeValue>();
            var attributes = ParseCheckoutAttributes(attributesXml);
            foreach (var attribute in attributes)
            {
                if (!attribute.ShouldHaveValues())
                    continue;

                var valuesStr = ParseValues(attributesXml, attribute.ID);
                foreach (string valueStr in valuesStr)
                {
                    if (!String.IsNullOrEmpty(valueStr))
                    {
                        int id;
                        if (int.TryParse(valueStr, out id))
                        {
                            var value = _checkoutAttributeService.GetCheckoutAttributeValueById(id);
                            if (value != null)
                                values.Add(value);
                        }
                    }
                }
            }
            return values;
        }

        /// <summary>
        /// Gets selected checkout attribute value
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="checkoutAttributeId">Checkout attribute identifier</param>
        /// <returns>Checkout attribute value</returns>
        public virtual IList<string> ParseValues(string attributesXml, int checkoutAttributeId)
        {
            var selectedCheckoutAttributeValues = new List<string>();
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(attributesXml);

                var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/CheckoutAttribute");
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node1.Attributes != null && node1.Attributes["ID"] != null)
                    {
                        string str1 = node1.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            if (id == checkoutAttributeId)
                            {
                                var nodeList2 = node1.SelectNodes(@"CheckoutAttributeValue/Value");
                                foreach (XmlNode node2 in nodeList2)
                                {
                                    string value = node2.InnerText.Trim();
                                    selectedCheckoutAttributeValues.Add(value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
            return selectedCheckoutAttributeValues;
        }

        /// <summary>
        /// Adds an attribute
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="ca">Checkout attribute</param>
        /// <param name="value">Value</param>
        /// <returns>Attributes</returns>
        public virtual string AddCheckoutAttribute(string attributesXml, CheckoutAttribute ca, string value)
        {
            string result = string.Empty;
            try
            {
                var xmlDoc = new XmlDocument();
                if (String.IsNullOrEmpty(attributesXml))
                {
                    var element1 = xmlDoc.CreateElement("Attributes");
                    xmlDoc.AppendChild(element1);
                }
                else
                {
                    xmlDoc.LoadXml(attributesXml);
                }
                var rootElement = (XmlElement)xmlDoc.SelectSingleNode(@"//Attributes");

                XmlElement attributeElement = null;
                //find existing
                var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/CheckoutAttribute");
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node1.Attributes != null && node1.Attributes["ID"] != null)
                    {
                        string str1 = node1.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            if (id == ca.ID)
                            {
                                attributeElement = (XmlElement)node1;
                                break;
                            }
                        }
                    }
                }

                //create new one if not found
                if (attributeElement == null)
                {
                    attributeElement = xmlDoc.CreateElement("CheckoutAttribute");
                    attributeElement.SetAttribute("ID", ca.ID.ToString());
                    rootElement.AppendChild(attributeElement);
                }

                var attributeValueElement = xmlDoc.CreateElement("CheckoutAttributeValue");
                attributeElement.AppendChild(attributeValueElement);

                var attributeValueValueElement = xmlDoc.CreateElement("Value");
                attributeValueValueElement.InnerText = value;
                attributeValueElement.AppendChild(attributeValueValueElement);

                result = xmlDoc.OuterXml;
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
            return result;
        }

        /// <summary>
        /// Removes checkout attributes which cannot be applied to the current cart and returns an update attributes in XML format
        /// </summary>
        /// <param name="attributesXml">Attributes in XML format</param>
        /// <param name="cart">Shopping cart items</param>
        /// <returns>Updated attributes in XML format</returns>
        public virtual string EnsureOnlyActiveAttributes(string attributesXml, IList<ShoppingCartItem> cart)
        {
            if (String.IsNullOrEmpty(attributesXml))
                return attributesXml;

            var result = attributesXml;

            //removing "shippable" checkout attributes if there's no any shippable products in the cart
            if (!cart.RequiresShipping())
            {
                //find attribute IDs to remove
                var checkoutAttributeIdsToRemove = new List<int>();
                var attributes = ParseCheckoutAttributes(attributesXml);
                foreach (var ca in attributes)
                    if (ca.ShippableProductRequired)
                        checkoutAttributeIdsToRemove.Add(ca.ID);
                //remove them from XML
                try
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(attributesXml);

                    var nodesToRemove = new List<XmlNode>();
                    foreach (XmlNode node in xmlDoc.SelectNodes(@"//Attributes/CheckoutAttribute"))
                    {
                        if (node.Attributes != null && node.Attributes["ID"] != null)
                        {
                            string str1 = node.Attributes["ID"].InnerText.Trim();
                            int id;
                            if (int.TryParse(str1, out id))
                            {
                                if (checkoutAttributeIdsToRemove.Contains(id))
                                {
                                    nodesToRemove.Add(node);
                                }
                            }
                        }
                    }
                    foreach(var node in nodesToRemove)
                    {
                        node.ParentNode.RemoveChild(node);
                    }
                    result = xmlDoc.OuterXml;
                }
                catch (Exception exc)
                {
                    Debug.Write(exc.ToString());
                }
            }
            return result;
        }
    }
}
