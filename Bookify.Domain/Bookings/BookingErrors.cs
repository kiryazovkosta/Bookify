﻿namespace Bookify.Domain.Bookings;

using Abstractions;

public static class BookingErrors
{
    public static Error NotFound = new(
        "Booking.Found",
        "The booking with specified identifier was not found");

    public static Error Overlap = new(
        "Booking.Overlap",
        "The current booking is overlapping with an existing one");

    public static readonly Error NotReserved = new(
        "Booking.NotReserved",
        "The booking is not reserved");

    public static readonly Error NotConfirmed = new(
        "Booking.NotConfirmed",
        "The booking is not confirmed");

    public static readonly Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "The booking has already started");
}