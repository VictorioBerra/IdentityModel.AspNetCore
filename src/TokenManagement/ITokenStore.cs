﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityModel.AspNetCore
{
    /// <summary>
    /// Storage abstraction for access and refresh tokens
    /// </summary>
    public interface ITokenStore
    {
        /// <summary>
        /// Stores tokens
        /// </summary>
        /// <param name="user">User the tokens belong to</param>
        /// <param name="accessToken">The access token</param>
        /// <param name="expiresIn">The access token lifetime in seconds</param>
        /// <param name="refreshToken">The refresh token</param>
        /// <returns></returns>
        Task StoreTokenAsync(ClaimsPrincipal user, string accessToken, int expiresIn, string refreshToken);

        /// <summary>
        /// Retrieves tokens from store
        /// </summary>
        /// <param name="user">User the tokens belong to</param>
        /// <returns>access and refresh token and access token expiration</returns>
        Task<(string accessToken, string refreshToken, DateTimeOffset expiration)> GetTokenAsync(ClaimsPrincipal user);
    }
}