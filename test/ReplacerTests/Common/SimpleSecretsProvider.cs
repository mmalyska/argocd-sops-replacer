﻿namespace ReplacerTests.Common;

using replacer.SecretsProvider;

public class SimpleSecretsProvider : ISecretsProvider
{
    private readonly string staticSecret;

    public SimpleSecretsProvider(string staticSecret)
        => this.staticSecret = staticSecret;

    public string GetSecret(string key)
        => staticSecret;
}
