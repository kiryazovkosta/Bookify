// ------------------------------------------------------------------------------------------------
//  <copyright file="Rating.cs" company="Business Management System Ltd.">
//      Copyright "2024" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

    private Rating(int value) => Value = value;

    public int Value { get; init; }

    public static Result<Rating> Create(int value)
    {
        if (value < 1 || value > 5)
        {
            return Result.Failure<Rating>(Invalid);
        }

        return new Rating(value);
    }
}