using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Dataleonlabs.Core;

namespace Dataleonlabs.Models.Companies;

/// <summary>
/// Represents a certificate file associated with an individual or company.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Certificat, CertificatFromRaw>))]
public sealed record class Certificat : JsonModel
{
    /// <summary>
    /// Unique identifier for the certificate.
    /// </summary>
    public string? ID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "id", value);
        }
    }

    /// <summary>
    /// Timestamp when the certificate was created.
    /// </summary>
    public DateTimeOffset? CreatedAt
    {
        get { return JsonModel.GetNullableStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "created_at", value);
        }
    }

    /// <summary>
    /// Name of the certificate file.
    /// </summary>
    public string? Filename
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "filename"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "filename", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Filename;
    }

    public Certificat() { }

    public Certificat(Certificat certificat)
        : base(certificat) { }

    public Certificat(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Certificat(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CertificatFromRaw.FromRawUnchecked"/>
    public static Certificat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CertificatFromRaw : IFromRawJson<Certificat>
{
    /// <inheritdoc/>
    public Certificat FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Certificat.FromRawUnchecked(rawData);
}
