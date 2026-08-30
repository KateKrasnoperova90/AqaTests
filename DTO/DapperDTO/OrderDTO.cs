using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AqaTest.DTO.DapperDTO;

public record OrderDTO
(
    long Id,
    long UserId,
    string OrderDate,
    string Status,
    string TotalPrice
);
