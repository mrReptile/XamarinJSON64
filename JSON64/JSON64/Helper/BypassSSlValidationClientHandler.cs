using Javax.Net.Ssl;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSON64.Helper
{
    internal class BypassSslValidationClientHandler : Xamarin.Android.Net.AndroidClientHandler
    {

        protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
        {
            return Android.Net.SSLCertificateSocketFactory.GetInsecure(1000, null);
        }

        protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
        {
            return new BypassHostnameVerifier();
        }

    }


    class BypassHostnameVerifier : Java.Lang.Object, IHostnameVerifier
    {

        public bool Verify(string hostname, ISSLSession session)
        {
            return true;
        }

    }
}
