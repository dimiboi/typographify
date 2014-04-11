namespace ArtLebedevStudio.WebServices
{
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;


    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "TypografSoap", Namespace = "http://typograf.artlebedev.ru/webservices/")]
    public class Typograph : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        public Typograph()
        {
            this.Url = "http://typograf.artlebedev.ru/webservices/typograf.asmx";
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://typograf.artlebedev.ru/webservices/ProcessText", RequestNamespace = "http://typograf.artlebedev.ru/webservices/", ResponseNamespace = "http://typograf.artlebedev.ru/webservices/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ProcessText(string text, int entityType, bool useBr, bool useP, int maxNobr)
        {
            object[] results = this.Invoke("ProcessText", new object[] {
                        text,
                        entityType,
                        useBr,
                        useP,
                        maxNobr});
            return ((string)(results[0]));
        }

        public System.IAsyncResult BeginProcessText(string text, int entityType, bool useBr, bool useP, int maxNobr, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("ProcessText", new object[] {
                        text,
                        entityType,
                        useBr,
                        useP,
                        maxNobr}, callback, asyncState);
        }

        public string EndProcessText(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}
