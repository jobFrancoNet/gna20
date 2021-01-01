// (c) 2003-2006 PPC Audit Inc., USA.   All Rights Reserved. 
//
function WCWCleanURL(str, bDeleteDomain)
{
	if (str == null || str.length == 0)
		return "";
		
    var strlwr = str.toLowerCase();
		
	var i = strlwr.indexOf("http://");
	
	if (i == 0)
		str = str.substr(7);
	else
	{
		i = strlwr.indexOf("https://");
		
		if (i == 0)
			str = str.substr(8);
	}
				
	i = str.indexOf("?");
	if ( i > -1 )
		str = str.substring(0,i);
		
	i = str.indexOf("&");
	if ( i > -1 )
		str = str.substring(0,i);

	for (;;) {
		i = str.lastIndexOf("/");
		
		if ( i == -1 || i < (str.length -1) )
			break;
			
		str = str.substring(0,i);			
	}
	
	while (str.indexOf("/") == 0)
		str = str.substring(1);
										
	if (bDeleteDomain)
	{
		i = str.indexOf("/");
		if ( i > -1 )
		{
			str = str.substring(i+1);	
		}
	}
		
	for (;;)
	{	
		i = str.indexOf("//");
		if (i == -1)
			break;
		str = str.replace(/\/\//g, "/");
	}
	
	return str;
}

function WCWGetDomain(str)
{
	if (str == null || str.length == 0)
		return "";
	
	str = WCWCleanURL(str).toLowerCase();
	
	var i = str.indexOf("/");
	if (i > -1)
		str = str.substring(0, i);
		
	var parts = str.split('.');
	
	var len = parts.length;
	
	if (len < 3)
		return str;

	var lastPart = parts[len-1];
	var secondPart;
			
	secondPart = parts[len-2];
	 
	var two = 2;
	
	if (lastPart == "uk" && secondPart == "co")
		++two;
	else if (lastPart == "au" && secondPart == "com")
		++two;
			
	if (len >= 0)
		return parts.splice(len-two, two).join('.');
	
	return null;
}
/* Version 1.2.2 30 Mar 2005 Adam Vandenberg with modifications by PPC Audit*/
function WCWQueryString(qs)
{
	this.params = new Object()
	this.get=WCWQueryString_get
	
	if (qs == null)
		qs=location.search.substring(1)

	if (qs.length == 0) return

	qs = qs.replace(/\+/g, ' ')
	var args = qs.split(/[&?]/)

	for (var i=0;i<args.length;i++)
	{
		var pair = args[i].split('=')
		name = unescape(pair[0])

		var value
		if (pair.length == 2)
			value = unescape(pair[1])
		else
			value = name
		
		var value2 = this.params[name];
		
		this.params[name] = (value2 == null) ? value : value2 + "," + value
	}
}

function WCWQueryString_get(key, default_)
{
	// This silly looking line changes UNDEFINED to NULL
	if (default_ == null) default_ = null;
	
	var value=this.params[key]
	if (value==null){value=default_}
	
	return value
}

function WCWFixKeywords(keywords) {
    keywords = unescape(keywords);
    keywords = keywords.replace(/\+/g, ' ');				
	return keywords.replace(/_/g, ' ');	
}

function WCWAudit(parms) {
	try {
		WCWAudit2(parms);
	}
	catch (ex) {
	}
}

function WCWAudit2(parms) {
var qs = new WCWQueryString;

var debug;
var keywords;
var source;
var referrer;

referrer = qs.params["wcw:referrer"];

// COPY HERE
var docDom = WCWGetDomain(document.URL);

if (referrer == null)
{
	referrer = document.referrer;
	
	if (referrer != null && (referrer.length == 0 || referrer == "blockedReferrer"))
		referrer = null;
}

var addSrc = 0;
	
{
	var ppca = new Array(14);
		
	ppca[0] = "wcw:ppc";
	ppca[1] = "wcw";
	ppca[2] = "ppc";
	ppca[3] = "src";
	ppca[4] = "source";
	ppca[5] = "partner";
	ppca[6] = "ovchn";	
	ppca[7] = "code";
	ppca[8] = "utm";
	ppca[9] = "js";
	ppca[10] = "se";
	ppca[11] = "referrer";
	ppca[12] = "ref";
	ppca[13] = "utm_source";
	
	var ppcReject = /^[0-9]+$/;
	
	var i;
	
	for(i = 0; i < ppca.length; i++)
	{
		if ((source = qs.params[ppca[i]]) != null)
		{
			if (source.match(ppcReject) != null)
			{
				source = null;
				continue;
			}
				
			if (ppca[i] == "code")
			{    
				addSrc = 1;
				
			    var matched = source.match(/^AdWords (.*)$/);
			    if (matched != null)
			    {
			        source = "AdWords";
			        
			        if (keywords == null)
			            keywords = matched[1];
			    }
			}
			
			break;	
		}
	}
}
	
if (debug == null)
{
    debug = qs.params["wcw:view"];
    if (debug == null)
	    debug = qs.params["debug"];
}

if (debug != null && debug != "1" && debug != "expand" && debug != "true")
	debug = null;

if (source == null || source.length == 0)
{
	if (debug == null)
	{
		return;
	}
	
	source = "";
}

var forcealert;
forcealert = qs.params["wcw:alert"];

if (forcealert == null)
	forcealert = qs.params["forcealert"];
	
if (forcealert != null && forcealert != "1" && forcealert != "2" && forcealert != "3")
	forcealert = null;
	
var test = qs.params["wcw:test"];
if (test != null && test != "1" && test != "true")
    test = null;

if ( debug == null
	&& forcealert == null
	&& test == null
	&& ( (referrer == null) 
	   || (WCWGetDomain(referrer) == docDom)
	   )
	)
{
	return;
}

if (referrer == null)
	referrer = "";
	
var auditorServer;

if (qs.params["wcw:dev"] == "1" || qs.params["wcw:dev"] == "true" || qs.params["wcwtesting"] == "1")
	auditorServer = "testauditor.whosclickingwho.com";
else
	auditorServer = "auditor.whosclickingwho.com";

if (keywords == null && qs.params["wcw:keywords"] == null)
{
	var regexps = new Array(4);
	
	regexps[0] = /__keyword--([^_]+)/;
	regexps[1] = /,keyword--([^,]+)/;
	regexps[2] = /^search\/web\/([^\/?&]+)/;
	regexps[3] = /\/search\/web\/([^\/?&]+)/;
	
	var kwd = new Array(47);
	
	kwd[0] = "keyword";
	kwd[1] = "keywords";
	kwd[2] = "Keywords";
	kwd[3] = "SearchKeywords";
	kwd[4] = "aqa";
	kwd[5] = "search";	
	kwd[6] = "query";
	kwd[7] = "Query";
	kwd[8] = "field-keywords";
	kwd[9] = "form_keyword";
	kwd[10] = "SearchString";
	kwd[11] = "search_string";
	kwd[12] = "terms";
	kwd[13] = "searched_on_google";
	kwd[14] = "searchfor";
	kwd[15] = "keyphrase";
	kwd[16] = "QueryText";
	kwd[17] = "siteSearchQuery";
	kwd[18] = "OVKEY";
	kwd[19] = "string";
	kwd[20] = "srch";
	kwd[21] = "term";
	kwd[22] = "Terms";	
	kwd[23] = "key";
	kwd[24] = "qkw";
	kwd[25] = "qry";
	kwd[26] = "for";
	kwd[27] = "kw";
	kwd[28] = "KW";
	kwd[29] = "qs";
	kwd[30] = "qu";
	kwd[31] = "qt";
	kwd[32] = "sp-q";
	kwd[33] = "show";
	kwd[34] = "where";
	kwd[35] = "qry_str";
	kwd[36] = "as_q";
	kwd[37] = "q1";
	kwd[38] = "st";
	kwd[39] = "ost";
	kwd[40] = "q";
	kwd[41] = "qq";		
	kwd[42] = "k";
	kwd[43] = "w";
	kwd[44] = "p";
	kwd[45] = "s";
	kwd[46] = "t";
	
	var domains = new Object();
	domains["googlesyndication.com"] = "ref";

	var regDomains = new Object();

	regDomains["thefreedictionary.com"] = /^([^\/]+)/;
	regDomains["wurldwide.net"] = /^search\/([^\/]+)/;
	regDomains["miprefunds.com"] = /^([^\.\/]+)/;
	regDomains["drugs.com"] = /\/search_([^\/]+)/;	
	
	var ignoreRe = /^[0-9]+$|[^ ]{31}/;
		
	var i;
	
	for(i = 0; i < 2; i++)
	{
		if (keywords != null && keywords.length > 0)
		{
			break;
		}
		
		var params;
		var str;
		var dom;
				
		if (i == 0)
		{
			str = referrer;
			dom = WCWGetDomain(str);
			var ind = str.indexOf("?");
			
			if (ind >= 0)
			{
				var qs2 = new WCWQueryString(str.substring(ind+1));	
				params = qs2.params;
			}
			else
			{
				params = null;
			}
		}
		else
		{
			str = document.URL;
			params = qs.params;
			dom = docDom;
		}

		var re = regDomains[dom];
			
		if (re != null)
		{
			var matched = WCWCleanURL(str,1).match(re);
				
			if (matched != null && matched[1].length > 0)
			{
				keywords = WCWFixKeywords(matched[1]);
				continue;
			}
		}
		else if (params != null)
		{
		var key2 = domains[dom];
		
		if (key2 != null)
		{
			str = params[key2];
				
			if (str == null)
			{
				continue;
			}
				
			str = unescape(str);
			ind = str.indexOf("?");
			
			if (ind >= 0)
			{
				var qs2 = new WCWQueryString(str.substring(ind+1));	
				params = qs2.params;
			}
			else
			{
				params = null;
			}
		}
		}
		
		var j;
		
		if (params != null)
		{
		for (j = 0; j < kwd.length; ++j)
		{
			var name = kwd[j];
			
			keywords = params[name];
			
			if (keywords != null && keywords.length > 0)
			{
				if (keywords.match(ignoreRe) == null)
				    break;
			}
			
			keywords = null;
		}
		}	
		
		if (keywords == null)
		{
		var clean = WCWCleanURL(str,1);
		for (j = 0; j < regexps.length; ++j)
		{
			var matched = clean.match(regexps[j]);
			
			if (matched != null && matched[1].length > 0)
			{
				keywords = WCWFixKeywords(matched[1]);			
				break;
			}
		}
		}					
	}
}
// Copy End

var uri = auditorServer
         + '/auditManager.aspx'
         + (document.location.search.length > 0 ? (document.location.search + '&') : '?')
         + (addSrc ? ("wcw:ppc=" + escape(source) + '&') : '')
		 + 'wcw:keyword=' 
		 + escape(keywords == null ? "" : keywords)
		 + '&wcw:url=' 
         + escape(document.URL)
         + '&wcw:fullreferrer=' 
         + escape(document.referrer == null ? "" : document.referrer);

var out;
out = '<iframe src="//' + uri;

if (debug != null)
	out = out + '" width=550 height=650 scrolling=true frameborder=2 STYLE=z-index:9999';
else
	out = out + '" frameborder=0 width=0 height=0';

out = out + "></iframe>";
document.writeln(out);
}
