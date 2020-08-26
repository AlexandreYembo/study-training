# Continuous Integration
Builds -> Test

- Developers merger their changes back to the main branch as often as possible.

- Changes are validated by creating a build and running automated tests against the build.

- Automated tests to check that application is not broken.

# Continuous Delivery
Acceptance Test -> Deploy to Staging -> Deploy to Production (Manual) -> Smoke Tests

- Automated your release process.

- Deploy at any point of time by clicking on a button.

- Decide to release daily, weekly, fortnightly or whenerver suits the business requirement.

- Deploying as early as possible make sure that the release small batches will be easy to troubleshoot in case of a problem.


# Continuous Deployment
Acceptance Test -> Deploye to Staging -> Deploy to Production (Automatic) -> Smoke Tests

- Every change that passes all stages of production pipeline is release to the customers.

- There is no human intervention.

- Only failed test will prevent new change to be deployed to production.

- Developers cna see their work go live minutes after they've finished working on it.
