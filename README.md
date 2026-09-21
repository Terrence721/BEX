# 💱 BEX — FX Strategy Engine

A ground-up architecture and design document for an FX strategy platform serving broker-dealer and commercial-banking needs. The core bet: every FX trading behavior (market making, TWAP/VWAP execution, smart order routing, hedging, NDF pricing) is an interchangeable strategy implementation — split by capability (quoting, execution, market-data reactivity) rather than one wide interface — built on the GoF Strategy pattern and selected/versioned at runtime instead of hardcoded per client or desk. Strategy Engine's core domain layer is implemented (see [`todo.md`](todo.md)); OMS, Risk, Pricing, the React workbench, and infrastructure are still design-phase.

## 🧭 Start Here

- **[Design Document](docs/fx-strategy-engine-design.md)** — business requirements, the strategy-pattern engine design, a 10-strategy catalog, GCP microservice architecture, CI/CD, security controls, and the phased rollout plan.
- **[`docs/diagrams/`](docs/diagrams/index.html)** — seven standalone diagrams going deeper than the design doc on each subsystem: strategy resolution, system architecture, order-placement sequence, data model, CI/CD, partner onboarding, deployment topology.
- **[`todo.md`](todo.md)** — the source of truth for what's done and what's left, phase by phase.
- **[Project board](https://github.com/users/Terrence721/projects/10)** — Backlog → Planned → In Progress → Verification & QA → Done, synced with `todo.md`.
- **[Milestones](https://github.com/Terrence721/BEX/milestones)** — one per rollout phase (MVP → Strategy breadth → Third-party GA → Scale).
- [Portfolio hub](https://terrence721.github.io/) · [GitHub profile](https://github.com/Terrence721) — this project in the context of this user's other work.

## 🧭 Why This Project Matters

The interesting design problem here isn't "build a trading system" — it's that a broker-dealer desk and a commercial bank's treasury desk need almost entirely different FX behaviors (market making and smart order routing vs. last-look cover-and-deal and corporate hedging programs) running on the *same* platform, for the *same* client base in some cases. Hardcoding that per-desk creates exactly the kind of branching logic nobody can safely change. The Strategy pattern turns that into a data problem instead of a code problem: which strategy a client gets is a `StrategyAssignment` row, resolved by capability-specific factories (`IQuotingStrategyFactory`/`IExecutionStrategyFactory`) and promoted through shadow → canary → live without a redeploy.

The same reasoning shows up in the infrastructure choices: one Cloud SQL instance per microservice with no cross-service joins, so a schema change in one service can't silently break another; a second CI/CD pipeline with an extra compliance gate specifically for anything that touches client-facing behavior or live trading logic, not for internal tooling; and branch protection on `main` that requires a PR for every change (even from the repo owner) but needs zero approvals, so the audit trail exists without blocking a solo maintainer.

## 🏗 Architecture Overview

.NET Core microservices on GKE (GCP), behind two separate edges — an internal-only gateway and an Apigee-fronted partner surface — communicating through named Pub/Sub topics, with React covering both the internal trading workbench and the partner/deployment-automation surfaces. See [`docs/diagrams/system-architecture.html`](docs/diagrams/system-architecture.html) for the full edge-to-data breakdown, or the [design doc](docs/fx-strategy-engine-design.md#high-level-system-architecture) for the reasoning behind it.

## 📋 Project Tracking

- [ ] **Phase 1 — MVP.** Market making + TWAP strategies, internal React workbench, single-region GCP, no third-party access. *Partially done — strategies + strategy resolution implemented; OMS/Risk/Pricing, Cloud SQL, React, Terraform, and tests still open.*
- [ ] **Phase 2 — Strategy breadth.** Add SOR, hedging, netting strategies; DR region live; partner portal in sandbox only.
- [ ] **Phase 3 — Third-party GA.** Apigee production tier, FIX connectivity, full strategy catalog, deployment automation dashboard for canary strategy promotion.
- [ ] **Phase 4 — Scale.** Multi-region active/active evaluation, corporate hedging-program strategies, expanded partner tiering.

Tracked in detail in [`todo.md`](todo.md) (the source of truth) and the [project board](https://github.com/users/Terrence721/projects/10); mirrored here as a quick-glance checklist. No phase is checked off in full yet.

## Repository Layout

```text
src/                .NET Core services — StrategyEngine.Domain implemented; OMS/Risk/Pricing not started
tests/              xUnit v3 test projects — infrastructure wired up, no tests written yet
BEX.slnx             Solution file (cutting-edge XML format, not classic .sln)
global.json          Pins the Microsoft.Testing.Platform test runner
docs/               Design doc and docs/diagrams/ (standalone HTML diagrams)
todo.md              Phase-by-phase progress log — the source of truth
.devcontainer/       Isolated dev environment — .NET 10 + Node 20, 19 scoped VS Code extensions
.github/             Dependabot config + build.yml CI workflow
.vscode/             Extension recommendations (for outside the Dev Container)
```

## 🖥 Getting Set Up

Open [`BEX.code-workspace`](BEX.code-workspace) in VS Code, then **Dev Containers: Reopen in Container** — this builds an isolated .NET 10 + Node 20 container with all 19 project-specific extensions pre-installed, entirely scoped to this repo so it never touches your global VS Code setup or any other project on the same machine. Once inside, `dotnet build BEX.slnx` builds the solution; `dotnet test` runs the test project (currently empty — no test methods written yet). There's no runnable application yet — no API, no OMS, no way to place an order end to end.

---

On AI-assisted development: this project uses Claude Code for AI-assisted implementation — every change is directed, reviewed, and merged by Terrence Daniels, with no commit co-author trailers.
