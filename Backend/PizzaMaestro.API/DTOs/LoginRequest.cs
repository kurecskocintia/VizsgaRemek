namespace PizzaMaestro.API.DTOs;

public record LoginRequest(
    string Email,
    string Password
);