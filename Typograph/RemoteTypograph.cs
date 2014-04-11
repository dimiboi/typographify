/*
	remotetypograf.cs
	C# (.NET) implementation of ArtLebedevStudio.RemoteTypograf class (web-service client)
	
	Copyright (c) Art. Lebedev Studio | http://www.artlebedev.ru/

	Typograf homepage: http://typograf.artlebedev.ru/
	Web-service address: http://typograf.artlebedev.ru/webservices/typograf.asmx
	WSDL-description: http://typograf.artlebedev.ru/webservices/typograf.asmx?WSDL
	
	Default charset: UTF-8

	Version: 1.0 (August 30, 2005)
	Author: Andrew Shitov (ash@design.ru)


	Example:
		ArtLebedevStudio.RemoteTypograf remoteTypograf = new ArtLebedevStudio.RemoteTypograf();
		Response.Write (remoteTypograf.ProcessText ("\"Âû âñå åùå êîå-êàê âåðñòàåòå\n â \"Âîðäå\"? - Òîãäà ìû èäåì ê âàì!\""));
*/

namespace ArtLebedevStudio
{
    public class RemoteTypograph
    {
        private int _entityType;
        private bool _useBr;
        private bool _useP;
        private int _maxNobr;

        public RemoteTypograph()
        {
            _entityType = 4;
            _useBr = true;
            _useP = true;
            _maxNobr = 3;
        }

        public void htmlEntities()
        {
            _entityType = 1;
        }
        public void xmlEntities()
        {
            _entityType = 2;
        }
        public void mixedEntities()
        {
            _entityType = 4;
        }
        public void noEntities()
        {
            _entityType = 3;
        }
        public void br(bool value)
        {
            _useBr = (bool)value;
        }
        public void p(bool value)
        {
            _useP = value;
        }
        public void nobr(int value)
        {
            _maxNobr = value;
        }

        public System.String ProcessText(System.String text)
        {
            ArtLebedevStudio.WebServices.Typograph remoteTypograf = new ArtLebedevStudio.WebServices.Typograph();

            return remoteTypograf.ProcessText(text, _entityType, _useBr, _useP, _maxNobr);
        }
    }
}
