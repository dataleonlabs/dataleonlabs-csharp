# Changelog

## 0.3.0 (2025-11-21)

Full Changelog: [v0.2.0...v0.3.0](https://github.com/dataleonlabs/dataleonlabs-csharp/compare/v0.2.0...v0.3.0)

### ⚠ BREAKING CHANGES

* **client:** improve names of some types
* **client:** use `DateTimeOffset` instead of `DateTime`
* **client:** flatten service namespaces
* **client:** interpret null as omitted in some properties
* **client:** make models immutable

### Features

* **api:** api update ([e1dfeda](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/e1dfedac99d16ee69a4c14b6625af744ff108c20))
* **client:** add `HttpResponse.ReadAsStream` method ([b4e49d7](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/b4e49d76804a59fd4708f063e6d127e9bfa2cc98))
* **client:** add cancellation token support ([92390c3](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/92390c32f0cd11ac62252f3b2f41558e1d8c6bb9))
* **client:** add response validation option ([2504425](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/25044258d6fd54f96f21f4a720a2fe62ac971d4d))
* **client:** add retries support ([475d7f2](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/475d7f26fc3ad560cbdb7d18308be0e1baec82f9))
* **client:** add support for option modification ([92e7a44](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/92e7a44988c954b15a2c08c50ac02b3ef416cfee))
* **client:** additional methods for positional params ([57a9b88](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/57a9b8867e60ad2299743f5aff920738bdcd001b))
* **client:** make models immutable ([279bc53](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/279bc53dff2ea5fd0dd5a7ba97231e6ff6b68e95))
* **client:** send `User-Agent` header ([b100448](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/b100448c8665eaecb6bdc500c23069ce78f3e5d5))
* **client:** send `X-Stainless-Arch` header ([ce7d14c](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/ce7d14cdc47983a8bf6319ada63b439bcbf7bd60))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([7be1745](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/7be1745355c19e18be3de27618affee64dc3f5a4))
* **client:** send `X-Stainless-Package-Version` headers ([3c4b5e9](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/3c4b5e9a97a51e9011957508a8c835ce55efb641))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([4f0bd1b](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/4f0bd1b8014116b4a70fd5998aa0e987fe143535))
* **client:** send `X-Stainless-Timeout` header ([752a03f](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/752a03f090be908005d762f00860b1806fd45ca4))
* **client:** support request timeout ([b984ead](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/b984ead6f8e785c8243eb90c1eaa84f8c6b9a5ee))


### Bug Fixes

* **client:** interpret null as omitted in some properties ([9b9e3d9](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/9b9e3d951ed2c114e3576335b074aacbccf8775a))
* **client:** use `DateTimeOffset` instead of `DateTime` ([8624dab](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/8624dab08e2d32cb8f77d986c4228c997fd10861))


### Performance Improvements

* **client:** optimize header creation ([876637a](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/876637a1a2e74d3f838f78339e3d6a9a9b26110d))


### Chores

* **client:** change name of underlying properties for models and params ([e110d09](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/e110d09f5efafc24d2f76b534ed4d690c51c43ac))
* **client:** deprecate some symbols ([78bac3e](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/78bac3e73061a1f93a791932427b3384d01588c1))
* **client:** simplify field validations ([2504425](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/25044258d6fd54f96f21f4a720a2fe62ac971d4d))
* **internal:** add prism log file to gitignore ([febbf4e](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/febbf4ef29c29fcb94cc8377e441caba20c0a392))
* **internal:** codegen related update ([ded0f28](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/ded0f28ccc69f20d9f4ddec7215e2627e653ac95))
* **internal:** codegen related update ([267da09](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/267da09fa890ee25214b0c9774632a5f74e20ff1))
* **internal:** extract `ClientOptions` struct ([3e6e76d](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/3e6e76d83921b70f626ef75ec21c3a3ee36aec4f))
* **internal:** full qualify some references ([5112ee2](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/5112ee2c8eb35ddab775cb6f18af74b21724f89c))
* **internal:** improve devcontainer ([0c984ec](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/0c984ec9184741bcb69711f03150a4a82db6b4b7))
* **internal:** minor improvements to csproj and gitignore ([01e1497](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/01e1497a78935f3a1f9af54d22f9062584bf846c))
* **internal:** reduce import qualification ([1a83145](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/1a831450147eccd98f15e95e16576798ba614518))
* **internal:** update release please config ([dfef5ea](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/dfef5ea9de9833d7234ca98e11cea2c653ee99ca))
* **internal:** update release please config ([cb15f6a](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/cb15f6a972d65bdfad50a82224dc2a1b3e54bec4))


### Documentation

* **client:** document `WithOptions` ([517a3f0](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/517a3f01fb38623a00f03323a73309b989ffaf91))
* **client:** document max retries ([9c78432](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/9c78432c75d334ea121b9b892123fabed0d0c823))
* **client:** document response validation ([40cb55d](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/40cb55df3a10c73ba131226c3ec5cd4d91abd42b))
* **client:** document timeout option ([7baa31e](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/7baa31e364d59f1cf1554addff5553af4bff8c6d))
* **client:** improve snippet formatting ([aa3523a](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/aa3523aa4ca2f09cae1a8458fd48a8c03a591287))
* **client:** separate comment content into paragraphs ([d29ae0d](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/d29ae0da8ebf5d84669974473a4a2bd96b46ada3))
* **internal:** add warning about implementing interface ([42015e8](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/42015e82ebb4a6050a2aef6551ddee7cbff9e6b6))


### Refactors

* **client:** flatten service namespaces ([07d270f](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/07d270f17a066080d2399ca6eec5fedace8e6729))
* **client:** improve names of some types ([b27a791](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/b27a7911755b4a74bc1b2d744d65f9d608068a1d))
* **client:** move some defaults out of `ClientOptions` ([f139b42](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/f139b423b2cc858346875d898d240b8ed03a6cc9))
* **client:** pass around `ClientOptions` instead of client ([ea1c056](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/ea1c0562c8ce6bdcb378843262e0ade49cb28035))

## 0.2.0 (2025-10-08)

Full Changelog: [v0.1.1...v0.2.0](https://github.com/dataleonlabs/dataleonlabs-csharp/compare/v0.1.1...v0.2.0)

### Features

* **client:** refactor exceptions ([9324b91](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/9324b91a8d78779735965bfba2567e3d79c55661))
* **client:** refactor unions ([e0c65a1](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/e0c65a14e6f1236177eb4f33afc25a4c67047024))
* **internal:** add dev container ([2749d0e](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/2749d0eb197c183d94e202c3b4c324f6597b4de9))


### Bug Fixes

* **internal:** remove example csproj ([14b5d39](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/14b5d395a0c4d2b35eb60c0d8bc883ffe7eaf422))

## 0.1.1 (2025-09-11)

Full Changelog: [v0.1.0...v0.1.1](https://github.com/dataleonlabs/dataleonlabs-csharp/compare/v0.1.0...v0.1.1)

### Bug Fixes

* **client:** handle multiple auth options gracefully ([e75999d](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/e75999d16f81336c2565ce541d0761c59b1144b6))

## 0.1.0 (2025-09-10)

Full Changelog: [v0.0.2...v0.1.0](https://github.com/dataleonlabs/dataleonlabs-csharp/compare/v0.0.2...v0.1.0)

### Features

* **api:** api update ([22da706](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/22da706cfaa59cbebe44df1f19632f2bb9428675))

## 0.0.2 (2025-08-28)

Full Changelog: [v0.0.1...v0.0.2](https://github.com/dataleonlabs/dataleonlabs-csharp/compare/v0.0.1...v0.0.2)

### Chores

* configure new SDK language ([20ed612](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/20ed612096304e94be4501de943c2bf72150823a))
* update SDK settings ([0a5c02b](https://github.com/dataleonlabs/dataleonlabs-csharp/commit/0a5c02bd06ff9f325085df5bbc8870de212cde8f))
