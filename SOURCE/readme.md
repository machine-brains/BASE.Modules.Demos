# BASE.Modules.Demos — Developer Briefing

> Hosts **demonstration content and exemplars**: sample data,
> walkthrough scenarios, and showcase surfaces used for evaluation,
> training, and pre-sales — never as the source of truth.

## Purpose

Demos exists so demonstration content has an obvious home and
cannot accidentally pollute production modules. It composes lower
modules to construct curated end-to-end scenarios without owning any
new domain vocabulary.

## Place in the Stack

- **Sits above:** every domain module it composes.
- **Depends on:** Shared contracts of composed modules.
- **Is consumed by:** demo environments, training environments,
  evaluation surfaces.
- **Is NOT consumed by:** any production-bearing module.

## Key Concepts

- **Demo Scenario** — a curated end-to-end walkthrough.
- **Seed Bundle** — the data package that primes a scenario.
- **Showcase Surface** — the consumer view of the scenario.

## Value

Without Demos as a dedicated module, sample data leaks into
production seeders and demo-only surfaces accrete inside business
modules.

## Common Sliding-Off / Anti-Patterns

- **Sample data in production seeders** instead of Demos.
- **New domain concepts** introduced here. Demos composes; it does
  not define.
- **Persisting demo identifiers** that collide with real ones. Use
  scenario-scoped namespaces.

## Canonical References

- `DOCUMENTATION/06.Development/MODULE-SOURCE-README-TEMPLATE.md`
