﻿namespace Budgethold.Modules.Wallets.Domain.Wallets.Events;

using Entities;
using Shared.Abstractions.Events;
using Shared.Abstractions.Kernel;

internal record ArchiveWallet(Wallet Wallet) : IDomainEvent;
