# 📝 TODO

**Last Updated:** September 21, 2026 (design phase — repo, docs, and tracking scaffolding complete; no service code written yet)

A phase-by-phase log of what's been done on this repo and what's still open. This is the source of truth for progress — the [README](README.md)'s Project Tracking checklist and the [project board](https://github.com/users/Terrence721/projects/10) both mirror this file, not the other way around.

**What this repo is:** a ground-up architecture and design document for an FX strategy platform serving broker-dealer and commercial-banking needs — every FX trading behavior designed as an interchangeable `IFxStrategy` implementation (the GoF Strategy pattern), selected/versioned at runtime instead of hardcoded per client or desk. See [README.md](README.md) for the project description and [docs/fx-strategy-engine-design.md](docs/fx-strategy-engine-design.md) for the full architecture.

## 🏁 Milestones

| # | Milestone | Date | Detail |
| - | - | - | - |
| 1 | Repo bootstrap & design foundation | 2026-09-21 | git init, default branch renamed `master` → `main`, full design doc (with embedded mermaid diagrams), 7 standalone HTML diagrams, Dev Container, branch protection, Dependabot, and this project board all live — before any service code. See "Done" below for full detail. |

Phases 1 through 4 (see **Still to do** below) haven't started — there's no GitHub milestone completion to report yet beyond the bootstrap above.

## At a glance

**Done, in full:**

| Item | Detail |
| --- | --- |
| Repo scaffolding | Design doc, `BEX.code-workspace`, Dev Container (.NET 8 + Node 20, 19 scoped extensions) — [#4](https://github.com/Terrence721/BEX/issues/4) |
| Repo hygiene & security | Branch protection (force-push/deletion blocked, PR required, enforced for admins), secret scanning + push protection, SECURITY.md — [#5](https://github.com/Terrence721/BEX/issues/5) |
| Dependency updates | `.github/dependabot.yml` (devcontainers ecosystem), verified working end to end — a real Dependabot PR bumping the Node feature, merged in #2 — [#6](https://github.com/Terrence721/BEX/issues/6) |
| Detailed diagrams | 7 standalone HTML diagrams in `docs/diagrams/`, matching AxonFramework-Full's established style — [#7](https://github.com/Terrence721/BEX/issues/7) |
| README + board linkage | README restructured to match the other repos' layout, linked to the diagrams index and project board — [#16](https://github.com/Terrence721/BEX/issues/16)/[#17](https://github.com/Terrence721/BEX/issues/17) |
| Project tracking | Public [project board](https://github.com/users/Terrence721/projects/10) (same Backlog/Planned/In Progress/Verification & QA/Done shape as the other repos), 4 milestones matching the phased rollout, 13 issues filed and triaged — [#18](https://github.com/Terrence721/BEX/issues/18) |

**This is still entirely the design phase.** No `src/` exists, nothing has been implemented, and no claim below should be read as "built" — only "designed" or "scaffolded." **Actually still open:** all of Phase 1 through Phase 4 — see **Still to do** below.

## ✅ Done

### Repository bootstrap

| Date | What |
| - | - |
| 2026-09-21 | `git init`; `.gitignore` (.NET/Node/Terraform/OS); default branch renamed `master` → `main`, old `master` deleted both locally and on GitHub. [#4](https://github.com/Terrence721/BEX/issues/4) |
| 2026-09-21 | Full design doc (`docs/fx-strategy-engine-design.md`) written — business requirements, the strategy-pattern engine design, a 10-strategy catalog, GCP microservice architecture, CI/CD, security controls, phased rollout — with embedded mermaid diagrams. Mirrored as a live, commentable [Claude Doc](https://claude.ai/artifact/48wHV3epZ5RdDBvbQbL8jN). [#4](https://github.com/Terrence721/BEX/issues/4) |
| 2026-09-21 | `BEX.code-workspace` (VS Code multi-root workspace) and `.devcontainer/` added — isolated .NET 8 + Node 20 container, 19 project-specific extensions verified installed inside it, entirely scoped to this repo. [#4](https://github.com/Terrence721/BEX/issues/4) |

### Documentation

| Date | What |
| - | - |
| 2026-09-21 | `docs/diagrams/` added — 7 standalone HTML pages (strategy pattern, system architecture, order-placement sequence, data model, CI/CD, partner onboarding, deployment topology) plus an index, matching the CSS-only, light/dark-themed style already established in AxonFramework-Full's `docs/diagrams/`. [#7](https://github.com/Terrence721/BEX/issues/7) |
| 2026-09-21 | README rebuilt around the same skeleton as GridPulse/AxonFramework-Full: Start Here, Why This Project Matters, Architecture Overview, Project Tracking, Repository Layout, Getting Set Up, AI-assisted-development disclosure — deliberately omitting sections that wouldn't be honest yet (badges, wiki link, run instructions), since no workflows or `src/` exist. [#17](https://github.com/Terrence721/BEX/issues/17) |

### Repo hygiene, security & CI

| Date | What |
| - | - |
| 2026-09-21 | Branch protection on `main`: force-push and deletion blocked, linear history required, enforced even for the repo owner; PR required before merge (0 approvals needed — solo-maintainer friendly, just requires the paper trail). [#5](https://github.com/Terrence721/BEX/issues/5) |
| 2026-09-21 | Secret scanning + push protection, Dependabot alerts + security updates, and CodeQL default setup all confirmed enabled (CodeQL has nothing to scan yet — `languages: []` — until real source lands). `SECURITY.md` added, pointing at GitHub's private vulnerability reporting. [#5](https://github.com/Terrence721/BEX/issues/5) |
| 2026-09-21 | `.github/dependabot.yml` added, scoped to the `devcontainers` ecosystem — the only one with a real manifest at this stage. Verified working end to end: Dependabot opened a real PR bumping `ghcr.io/devcontainers/features/node` 1.7.1 → 2.1.0, merged. [#6](https://github.com/Terrence721/BEX/issues/6) |
| 2026-09-21 | `cspell.json` added locally (gitignored, not shared) seeded with this project's own vocabulary. |

### Project tracking

| Date | What |
| - | - |
| 2026-09-21 | [Project board](https://github.com/users/Terrence721/projects/10) created — same Backlog/Planned/In Progress/Verification & QA/Done columns, colors, and Board-layout view as the other 7 repos' boards, confirmed via direct comparison. Linked to this repo. [#18](https://github.com/Terrence721/BEX/issues/18) |
| 2026-09-21 | 4 milestones created (Phase 1 — MVP through Phase 4 — Scale), matching the design doc's rollout table. 13 issues filed: 7 closed (Done, this table), 2 Planned, 4 Backlog — see **Still to do** below. [#18](https://github.com/Terrence721/BEX/issues/18) |
| 2026-09-21 | This project added to the [GitHub profile README](https://github.com/Terrence721/Terrence721) and the [portfolio hub](https://terrence721.github.io/) as a design-phase card — no fabricated metrics, since nothing's built yet. |

## 🚧 Still to do

**Phase 1 — MVP** (market making + TWAP strategies, internal React workbench, single-region GCP, no third-party access — [milestone](https://github.com/Terrence721/BEX/milestone/1)):

| # | Item | Status |
| - | - | - |
| 1 | Scaffold .NET Core solution structure (Strategy Engine, OMS, Risk, Pricing) | Not started — [#8](https://github.com/Terrence721/BEX/issues/8) |
| 2 | Implement `IFxStrategy` + `MarketMakingStrategy` + `TwapExecutionStrategy` | Not started — [#9](https://github.com/Terrence721/BEX/issues/9) |
| 3 | Cloud SQL schema + migrations (Instruments, Quotes, Orders, Trades) | Not started — [#10](https://github.com/Terrence721/BEX/issues/10) |
| 4 | Internal React workbench shell (blotter + strategy console) | Not started — [#11](https://github.com/Terrence721/BEX/issues/11) |
| 5 | Terraform base — VPC, GKE cluster, Cloud SQL (single region) | Not started — [#12](https://github.com/Terrence721/BEX/issues/12) |
| 6 | Internal CI/CD pipeline (Cloud Build → dev → UAT canary → prod) | Not started — [#13](https://github.com/Terrence721/BEX/issues/13) |

**Phases 2-4** — not yet broken into concrete tasks, tracked as one milestone each until their turn comes:

| # | Item | Status |
| - | - | - |
| 7 | [Phase 2 — Strategy breadth](https://github.com/Terrence721/BEX/milestone/2) — SOR, hedging, netting strategies; DR region; partner portal in sandbox | Backlog |
| 8 | [Phase 3 — Third-party GA](https://github.com/Terrence721/BEX/milestone/3) — Apigee production tier, FIX connectivity, full strategy catalog, canary strategy promotion | Backlog |
| 9 | [Phase 4 — Scale](https://github.com/Terrence721/BEX/milestone/4) — multi-region active/active evaluation, corporate hedging programs, expanded partner tiering | Backlog |
