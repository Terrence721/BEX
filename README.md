# BEX — FX Strategy Engine

Design for an FX strategy platform serving broker-dealer and commercial-banking needs: a pluggable `IFxStrategy` engine (GoF Strategy pattern) on .NET Core microservices, GKE/GCP, Cloud SQL, and React (internal trading UI, partner portal, deployment automation dashboard) for both internal and third-party access.

- Full design doc: [docs/fx-strategy-engine-design.md](docs/fx-strategy-engine-design.md)
- Expanded diagrams: [docs/diagrams/](docs/diagrams/index.html)
- Open `BEX.code-workspace` in VS Code, or use **Reopen in Container** (see `.devcontainer/`) for an isolated dev environment scoped to just this project.
- Work tracked on a public [project board](https://github.com/users/Terrence721/projects/10), phased per the design doc's [rollout plan](docs/fx-strategy-engine-design.md#non-functional-requirements-dr--phased-roadmap).
