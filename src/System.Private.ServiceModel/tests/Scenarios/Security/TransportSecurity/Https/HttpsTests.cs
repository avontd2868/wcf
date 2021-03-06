// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using Xunit;

public static class Security_TransportSecurity_Https_HttpsTests
{
    // Client: CustomBinding set MessageVersion to Soap11
    // Server: BasicHttpsBinding default value is Soap11
    [Fact]
    [OuterLoop]
    public static void CrossBinding_Soap11_EchoString()
    {
        string variationDetails = "Client:: CustomBinding/MessageVersion=Soap11\nServer:: BasicHttpsBinding/DefaultValues";
        StringBuilder errorBuilder = new StringBuilder();

        CustomBinding binding = new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8), new HttpsTransportBindingElement());
        ScenarioTestHelpers.RunBasicEchoTest(binding, Endpoints.Https_DefaultBinding_Address, variationDetails, errorBuilder);

        Assert.True(errorBuilder.Length == 0, "Test case FAILED with errors: " + errorBuilder.ToString());
    }

    // Client and Server bindings setup exactly the same using default settings.
    [Fact]
    [OuterLoop]
    public static void SameBinding_DefaultSettings_EchoString()
    {
        string variationDetails = "Client:: CustomBinding/DefaultValues\nServer:: CustomBinding/DefaultValues";
        StringBuilder errorBuilder = new StringBuilder();

        CustomBinding binding = new CustomBinding(new TextMessageEncodingBindingElement(), new HttpsTransportBindingElement());
        ScenarioTestHelpers.RunBasicEchoTest(binding, Endpoints.HttpsSoap12_Address, variationDetails, errorBuilder);

        Assert.True(errorBuilder.Length == 0, "Test case FAILED with errors: " + errorBuilder.ToString());
    }

    // Client and Server bindings setup exactly the same using Soap11
    [Fact]
    [OuterLoop]
    public static void SameBinding_Soap11_EchoString()
    {
        string variationDetails = "Client:: CustomBinding/MessageVersion=Soap11\nServer:: CustomBinding/MessageVersion=Soap11";
        StringBuilder errorBuilder = new StringBuilder();

        CustomBinding binding = new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap11, Encoding.UTF8), new HttpsTransportBindingElement());
        ScenarioTestHelpers.RunBasicEchoTest(binding, Endpoints.HttpsSoap11_Address, variationDetails, errorBuilder);

        Assert.True(errorBuilder.Length == 0, "Test case FAILED with errors: " + errorBuilder.ToString());
    }

    // Client and Server bindings setup exactly the same using Soap12
    [Fact]
    [OuterLoop]
    public static void SameBinding_Soap12_EchoString()
    {
        string variationDetails = "Client:: CustomBinding/MessageVersion=Soap12\nServer:: CustomBinding/MessageVersion=Soap12";
        StringBuilder errorBuilder = new StringBuilder();

        CustomBinding binding = new CustomBinding(new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8), new HttpsTransportBindingElement());
        ScenarioTestHelpers.RunBasicEchoTest(binding, Endpoints.HttpsSoap12_Address, variationDetails, errorBuilder);

        Assert.True(errorBuilder.Length == 0, "Test case FAILED with errors: " + errorBuilder.ToString());
    }
}
