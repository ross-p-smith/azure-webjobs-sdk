﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.WebJobs.Host.Blobs.Listeners
{
    // IStorageBlobClients are flyweights; distinct references do not equate to distinct storage accounts.
    internal class CloudBlobClientComparer : IEqualityComparer<CloudBlobClient>
    {
        public bool Equals(CloudBlobClient x, CloudBlobClient y)
        {
            if (x == null)
            {
                throw new ArgumentNullException("x");
            }
            if (y == null)
            {
                throw new ArgumentNullException("y");
            }

            return x.BaseUri == y.BaseUri;
        }

        public int GetHashCode(CloudBlobClient obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return obj.BaseUri.GetHashCode();
        }
    }
}
