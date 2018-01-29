﻿/*
Government Usage Rights Notice:  The U.S. Government retains unlimited, royalty-free usage rights to this software, but not ownership, as provided by Federal law.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

•	Redistributions of source code must retain the above Government Usage Rights Notice, this list of conditions and the following disclaimer.

•	Redistributions in binary form must reproduce the above Government Usage Rights Notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.

•	Neither the names of the National Library of Medicine, the National Institutes of Health, nor the names of any of the software developers may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE U.S. GOVERNMENT AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITEDTO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE U.S. GOVERNMENT
OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using Imppoa.HtmlZoning.Dom;
using Imppoa.HtmlZoning.TreeStructure;
using Microsoft.Win32;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Imppoa.HtmlRendering
{
    /// <summary>
    /// MsHtml document factory
    /// </summary>
    public class MsHtmlDocumentFactory
    {
        private readonly DefaultStyleLookup _defaultStyleLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="MsHtmlDocumentFactory"/> class
        /// </summary>
        /// <param name="defaultStyleLookup">The default style lookup</param>
        public MsHtmlDocumentFactory(DefaultStyleLookup defaultStyleLookup)
        {
            _defaultStyleLookup = defaultStyleLookup;
        }

        /// <summary>
        /// Creates an instance
        /// </summary>
        /// <param name="msHtmlDoc">The MSHTML document</param>
        /// <param name="url">The URL</param>
        /// <returns>
        /// the created instance
        /// </returns>
        public MsHtmlDocument Create(object msHtmlDoc, string url)
        {
            var msRoot = IeDomHelper.GetRootElement(msHtmlDoc);
 
            var elements = CopyElements(msRoot);
            var elementLookup = elements.Select(e => (TreeNode) e).ToDictionary(e => e.Id);
            foreach (var element in elements)
            {
                element.Link(elementLookup);
            }

            var info = this.CreateInfo(url);
            return new MsHtmlDocument(elements.First(), info, _defaultStyleLookup);
        }

        /// <summary>
        /// Copies the data from the MSHTML elements
        /// </summary>
        /// <param name="msRoot">The root MSHTML element</param>
        /// <returns>
        /// Array of copied elements
        /// </returns>
        private IEnumerable<MsHtmlElement> CopyElements(IHTMLElement msRoot)
        {
            var doc2 = (IHTMLDocument2)msRoot.document;
            int sourceIndexOffset = msRoot.sourceIndex;
            var elementFactory = new MsHtmlElementFactory(sourceIndexOffset, _defaultStyleLookup);

            var elements = new List<MsHtmlElement>();
            for (int i = sourceIndexOffset; i < doc2.all.length; i++)
            {
                var msEl = doc2.all.item(i);
                var el = elementFactory.Create(msEl);
                elements.Add(el);
            }
            return elements;
        }

        /// <summary>
        /// Creates the HTML document information
        /// </summary>
        /// <param name="url">The URL</param>
        /// <returns>the HTML document information</returns>
        private HtmlDocumentInfo CreateInfo(string url)
        {
            string browserVersion = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Internet Explorer").GetValue("svcVersion").ToString();
            string codeVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var creationDate = DateTime.Now;
            var info = new HtmlDocumentInfo(url, browserVersion, codeVersion, creationDate);
            return info;
        }
    }
}
