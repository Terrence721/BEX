# 📝 TODO

**Last Updated:** September 21, 2026 (Phase 1 underway — StrategyEngine.Domain's core implementation complete, 22 files, plus xUnit v3 test infrastructure wired up; no tests written yet, and OMS/Risk/Pricing/Terraform/React are all still not started)

A phase-by-phase log of what's been done on this repo and what's still open. This is the source of truth for progress — the [README](README.md)'s Project Tracking checklist and the [project board](https://github.com/users/Terrence721/projects/10) both mirror this file, not the other way around.

**What this repo is:** a ground-up architecture and design document for an FX strategy platform serving broker-dealer and commercial-banking needs — every FX trading behavior designed as an interchangeable strategy implementation (the GoF Strategy pattern), selected/versioned at runtime instead of hardcoded per client or desk. See [README.md](README.md) for the project description and [docs/fx-strategy-engine-design.md](docs/fx-strategy-engine-design.md) for the full architecture.

## 🏁 Milestones

| # | Milestone | Date | Detail |
| - | - | - | - |
| 1 | Repo bootstrap & design foundation | 2026-09-21 | git init, default branch renamed `master` → `main`, full design doc (with embedded mermaid diagrams), 7 standalone HTML diagrams, Dev Container, branch protection, Dependabot, and this project board all live — before any service code. |
| 2 | StrategyEngine.Domain core implementation | 2026-09-21 | `.NET 10` + `.slnx` solution, and the full Strategy Engine domain layer: an ISP-conscious decomposition (`IStrategyIdentity`/`IQuotingStrategy`/`IExecutionStrategy`/`IMarketDataReactive`, not one wide interface), `MarketMakingStrategy` + `TwapExecutionStrategy`, a DRY-refactored `ILatestPriceProvider`, and split `StrategyFactory` resolution (`IQuotingStrategyFactory`/`IExecutionStrategyFactory`) keyed by `(ClientId, InstrumentClass)` against `StrategyAssignment`. 22 files, one PR each. See "Done" below for full detail. |

[Phase 1 — MVP](https://github.com/Terrence721/BEX/milestone/1) itself is not closed — 5 of 6 tracked items remain (see **Still to do**). Phases 2-4 haven't started.

## At a glance

**Done, in full:**

| Item | Detail |
| --- | --- |
| Repo scaffolding | Design doc, `BEX.code-workspace`, Dev Container — [#4](https://github.com/Terrence721/BEX/issues/4) |
| Repo hygiene & security | Branch protection, secret scanning + push protection, SECURITY.md — [#5](https://github.com/Terrence721/BEX/issues/5) |
| Dependency updates | `.github/dependabot.yml`, verified working end to end — [#6](https://github.com/Terrence721/BEX/issues/6) |
| Detailed diagrams | 7 standalone HTML diagrams in `docs/diagrams/` — [#7](https://github.com/Terrence721/BEX/issues/7) |
| README + board linkage | README restructured, linked to diagrams/board — [#16](https://github.com/Terrence721/BEX/issues/16)/[#17](https://github.com/Terrence721/BEX/issues/17) |
| Project tracking | Public [project board](https://github.com/users/Terrence721/projects/10), 4 milestones, issues filed and triaged — [#18](https://github.com/Terrence721/BEX/issues/18) |
| **StrategyEngine.Domain** | Strategy-pattern engine implemented — see Milestone 2 above. 22 files, 0 warnings/errors. — [#9](https://github.com/Terrence721/BEX/issues/9) |
| **xUnit v3 test infrastructure** | `global.json`, test project, wired into the solution, project reference to StrategyEngine.Domain. **No test files written yet.** — [#69](https://github.com/Terrence721/BEX/issues/69) |

**Not done:** OMS, Risk, and Pricing services (any layer); Cloud SQL schema/migrations; the internal React workbench; Terraform/GKE; CI/CD beyond a basic build check; and — despite the test *project* existing — no actual test has been written against `StrategyEngine.Domain` yet. **Actually still open:** the rest of Phase 1 (see **Still to do**) plus all of Phases 2-4.

## ✅ Done

### Repository bootstrap

| Date | What |
| - | - |
| 2026-09-21 | `git init`; `.gitignore`; default branch renamed `master` → `main`. [#4](https://github.com/Terrence721/BEX/issues/4) |
| 2026-09-21 | Full design doc (`docs/fx-strategy-engine-design.md`) written, with embedded mermaid diagrams. Mirrored as a live, commentable [Claude Doc](https://claude.ai/artifact/48wHV3epZ5RdDBvbQbL8jN). [#4](https://github.com/Terrence721/BEX/issues/4) |
| 2026-09-21 | `BEX.code-workspace` and `.devcontainer/` added — isolated container, 19 project-specific extensions, entirely scoped to this repo. [#4](https://github.com/Terrence721/BEX/issues/4) |

### Documentation

| Date | What |
| - | - |
| 2026-09-21 | `docs/diagrams/` added — 7 standalone HTML pages, matching AxonFramework-Full's established style. [#7](https://github.com/Terrence721/BEX/issues/7) |
| 2026-09-21 | README rebuilt around the GridPulse/AxonFramework-Full skeleton. [#17](https://github.com/Terrence721/BEX/issues/17) |

### Repo hygiene, security & CI

| Date | What |
| - | - |
| 2026-09-21 | Branch protection on `main`: force-push/deletion blocked, linear history required, PR required (0 approvals), enforced for admins. [#5](https://github.com/Terrence721/BEX/issues/5) |
| 2026-09-21 | Secret scanning + push protection, Dependabot alerts + security updates, CodeQL default setup confirmed enabled. `SECURITY.md` added. [#5](https://github.com/Terrence721/BEX/issues/5) |
| 2026-09-21 | `.github/dependabot.yml` added (devcontainers ecosystem) — verified working end to end via a real merged Dependabot PR. [#6](https://github.com/Terrence721/BEX/issues/6) |
| 2026-09-21 | `.github/workflows/build.yml` added, matching AxonFramework-Full's exactly — checkout → setup .NET 10 → `dotnet build BEX.slnx` on push/PR. First real CI run confirmed passing. [#33](https://github.com/Terrence721/BEX/pull/33) |
| 2026-09-21 | Dev Container upgraded from `.NET 8` to `.NET 10` SDK, needed for `.slnx` support. Rebuilt and re-verified (`dotnet sln BEX.slnx list` runs clean inside it). [#22](https://github.com/Terrence721/BEX/pull/22) |
| 2026-09-21 | Repo's "Automatically delete head branches" setting enabled; 33 stale branches from already-merged PRs cleaned up (drift sweep). |

### Project tracking

| Date | What |
| - | - |
| 2026-09-21 | [Project board](https://github.com/users/Terrence721/projects/10) created — same 5-column shape as the other 7 repos' boards. Linked to this repo. [#18](https://github.com/Terrence721/BEX/issues/18) |
| 2026-09-21 | 4 milestones created (Phase 1 — MVP through Phase 4 — Scale). Issues filed and triaged. [#18](https://github.com/Terrence721/BEX/issues/18) |
| 2026-09-21 | This project added to the [GitHub profile README](https://github.com/Terrence721/Terrence721) and the [portfolio hub](https://terrence721.github.io/). |

### StrategyEngine.Domain — the strategy-pattern engine (#9)

One PR per file, each verified building clean before merge. Full file/PR/commit list lives on [issue #9](https://github.com/Terrence721/BEX/issues/9) itself rather than duplicated here — summary:

| Date | What |
| - | - |
| 2026-09-21 | **Solution setup:** `BEX.slnx` (cutting-edge XML format, not classic `.sln`) and `StrategyEngine.Domain` (empty class library, `net10.0`), wired together. [#21](https://github.com/Terrence721/BEX/pull/21)/[#23](https://github.com/Terrence721/BEX/pull/23)/[#24](https://github.com/Terrence721/BEX/pull/24) |
| 2026-09-21 | **ISP-conscious interface decomposition**, replacing the design doc's original single wide `IFxStrategy` sketch: `IStrategyIdentity`, `IQuotingStrategy`, `IExecutionStrategy`, `IMarketDataReactive` — each strategy implements only what it actually does, decided after an explicit design discussion rather than built as first sketched. [#25](https://github.com/Terrence721/BEX/pull/25)/[#28](https://github.com/Terrence721/BEX/pull/28)/[#34](https://github.com/Terrence721/BEX/pull/34)/[#36](https://github.com/Terrence721/BEX/pull/36) |
| 2026-09-21 | Supporting domain types built bottom-up, each compiling before the next depended on it: `Quote`, `RequestContext`, `Order`, `OrderSide`, `ExecutionStatus`, `ExecutionPlan`, `Tick`, `StrategyAssignment`. |
| 2026-09-21 | `MarketMakingStrategy` (spread-based two-way quoting) and `TwapExecutionStrategy` (fills at offer/bid using current market price) implemented — deliberately scoped: no inventory-based skew, no real time-slicing yet, documented as follow-up rather than silently approximated as done. [#37](https://github.com/Terrence721/BEX/pull/37)/[#41](https://github.com/Terrence721/BEX/pull/41) |
| 2026-09-21 | **DRY refactor:** `MarketMakingStrategy` originally implemented `IMarketDataReactive` directly with its own tick dictionary; caught before `TwapExecutionStrategy` would have duplicated the same pattern. Extracted `ILatestPriceProvider`/`InMemoryLatestPriceProvider`, refactored `MarketMakingStrategy` to depend on it instead — tick-tracking now lives in exactly one place. [#38](https://github.com/Terrence721/BEX/pull/38)/[#39](https://github.com/Terrence721/BEX/pull/39)/[#40](https://github.com/Terrence721/BEX/pull/40) |
| 2026-09-21 | **StrategyFactory resolution**, also split by capability rather than one factory: `IQuotingStrategyFactory`/`QuotingStrategyFactory` and `IExecutionStrategyFactory`/`ExecutionStrategyFactory`, each resolving `(ClientId, InstrumentClass)` → `StrategyAssignment` → concrete strategy via an injected registry (composition, not a shared base class). A "shared lookup collaborator" was proposed and then deliberately *not* built — the only shared logic was one line, not worth its own abstraction. [#60](https://github.com/Terrence721/BEX/pull/60)–[#65](https://github.com/Terrence721/BEX/pull/65) |

### xUnit v3 test infrastructure (#69)

| Date | What |
| - | - |
| 2026-09-21 | `global.json` (`Microsoft.Testing.Platform` runner), `StrategyEngine.Domain.Tests.csproj` (`xunit.v3.mtp-v2`, confirmed by inspecting a real generated template rather than assuming the package name), `xunit.runner.json`, wired into `BEX.slnx`, project reference to `StrategyEngine.Domain`. All verified building clean. **No test methods written yet — this is infrastructure only.** [#66](https://github.com/Terrence721/BEX/pull/66)–[#74](https://github.com/Terrence721/BEX/pull/74) |

## 🚧 Still to do

**Phase 1 — MVP** ([milestone](https://github.com/Terrence721/BEX/milestone/1), 1 of 6 tracked items done):

| # | Item | Status |
| - | - | - |
| 1 | Scaffold .NET Core solution structure (Strategy Engine, OMS, Risk, Pricing) | **Partially done** — Strategy Engine's Domain layer complete; Application/Infrastructure/API layers, and OMS/Risk/Pricing entirely, not started — [#8](https://github.com/Terrence721/BEX/issues/8) |
| 2 | ~~Implement IFxStrategy + MarketMakingStrategy + TwapExecutionStrategy~~ | **Done** — see StrategyEngine.Domain above — [#9](https://github.com/Terrence721/BEX/issues/9) |
| 3 | Cloud SQL schema + migrations (Instruments, Quotes, Orders, Trades) | Not started — [#10](https://github.com/Terrence721/BEX/issues/10) |
| 4 | Internal React workbench shell (blotter + strategy console) | Not started — [#11](https://github.com/Terrence721/BEX/issues/11) |
| 5 | Terraform base — VPC, GKE cluster, Cloud SQL (single region) | Not started — [#12](https://github.com/Terrence721/BEX/issues/12) |
| 6 | Internal CI/CD pipeline (Cloud Build → dev → UAT canary → prod) | Not started — [#13](https://github.com/Terrence721/BEX/issues/13) — a basic build-check workflow exists (`build.yml`), but not the full pipeline described here |

Not yet tracked as its own issue, but a real gap: **no tests exist against `StrategyEngine.Domain`** despite the test project being fully wired up. Worth its own issue before Phase 1 is called done.

**Phases 2-4** — not yet broken into concrete tasks:

| # | Item | Status |
| - | - | - |
| 7 | [Phase 2 — Strategy breadth](https://github.com/Terrence721/BEX/milestone/2) — SOR, hedging, netting strategies; DR region; partner portal in sandbox | Backlog |
| 8 | [Phase 3 — Third-party GA](https://github.com/Terrence721/BEX/milestone/3) — Apigee production tier, FIX connectivity, full strategy catalog, canary strategy promotion | Backlog |
| 9 | [Phase 4 — Scale](https://github.com/Terrence721/BEX/milestone/4) — multi-region active/active evaluation, corporate hedging programs, expanded partner tiering | Backlog |
