using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.ResponseHandling
{
    public class Response
    {
        public Response(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = GetStatusCodeMessage(statusCode);
        }

        public int StatusCode { get; set; }

        public string Message { get; set; }

        public static string GetStatusCodeMessage(int statusCode) 
            => statusCode switch
        {
            // Informational responses (100–199)
            100 => "Continue - Keep going with the request.",
            101 => "Switching Protocols - Switching protocols as requested.",
            102 => "Processing - Request received, still processing.",
            103 => "Early Hints - Headers available early.",

            // Successful responses (200–299)
            200 => "OK - Success.",
            201 => "Created - Resource created successfully.",
            202 => "Accepted - Request accepted, processing.",
            203 => "Non-Authoritative - Modified response.",
            204 => "No Content - No content to return.",
            205 => "Reset Content - Reset view.",
            206 => "Partial Content - Partial resource delivered.",
            207 => "Multi-Status - Multiple responses.",
            208 => "Already Reported - Already handled.",
            226 => "IM Used - Instance manipulation applied.",

            // Redirection messages (300–399)
            300 => "Multiple Choices - Multiple options available.",
            301 => "Moved Permanently - Resource moved permanently.",
            302 => "Found - Resource temporarily moved.",
            303 => "See Other - Find resource at another URI.",
            304 => "Not Modified - Resource not modified.",
            305 => "Use Proxy - Use a proxy server.",
            307 => "Temporary Redirect - Temporary URI redirection.",
            308 => "Permanent Redirect - Permanent URI redirection.",

            // Client error responses (400–499)
            400 => "Bad Request - Invalid request.",
            401 => "Unauthorized - Authentication needed.",
            402 => "Payment Required - Payment needed.",
            403 => "Forbidden - Access denied.",
            404 => "Not Found - Resource not found.",
            405 => "Method Not Allowed - Unsupported request method.",
            406 => "Not Acceptable - Unacceptable resource format.",
            407 => "Proxy Authentication Required - Proxy authentication needed.",
            408 => "Request Timeout - Request took too long.",
            409 => "Conflict - Conflict with current state.",
            410 => "Gone - Resource permanently gone.",
            411 => "Length Required - Content length needed.",
            412 => "Precondition Failed - Precondition not met.",
            413 => "Payload Too Large - Request too large.",
            414 => "URI Too Long - URI too long to process.",
            415 => "Unsupported Media Type - Unsupported format.",
            416 => "Range Not Satisfiable - Requested range unavailable.",
            417 => "Expectation Failed - Expectation can't be met.",
            418 => "I'm a Teapot - Teapot can't brew coffee.",
            421 => "Misdirected Request - Wrong server.",
            422 => "Unprocessable - Semantic error in request.",
            423 => "Locked - Resource is locked.",
            424 => "Failed Dependency - Previous request failed.",
            425 => "Too Early - Request too early to process.",
            426 => "Upgrade Required - Upgrade needed.",
            428 => "Precondition Required - Conditions required.",
            429 => "Too Many Requests - Too many requests.",
            431 => "Headers Too Large - Headers too large to process.",
            451 => "Unavailable - Legal restriction.",

            // Server error responses (500–599)
            500 => "Server Error - Server encountered an issue.",
            501 => "Not Implemented - Not supported by server.",
            502 => "Bad Gateway - Invalid response from upstream.",
            503 => "Service Unavailable - Server can't handle request.",
            504 => "Gateway Timeout - No response from upstream.",
            505 => "HTTP Version Not Supported - Version unsupported.",
            506 => "Variant Also Negotiates - Circular negotiation.",
            507 => "Insufficient Storage - Not enough storage.",
            508 => "Loop Detected - Loop detected in request.",
            510 => "Not Extended - Extra extension needed.",
            511 => "Network Authentication Required - Network auth needed.",

            // Catch-all for unknown status codes
            _ => "Unknown Status Code."
        };


    }
}
