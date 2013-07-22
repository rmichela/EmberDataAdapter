EmberDataAdapter
================

An adapter for Asp.net Web API for emitting Ember Data rest adapter compliant JSON.

This project is in EXTREME ALPHA, but some things actually work.

The goal of this project is to create an adapter layer between ASP.net Web API-based web services and the Ember Data Rest Adapter that supports create, retrieve, update, and delete operations out of the box. To achieve this goal, a number of extensions were implemented to the stock Json.net serialization pipeline to translate a traditional hierarchically serialized JSON object into an object graph more suitable for use with Ember Data. Since the Json.net parser was not modified directly, the full fidelity of Json.net's object annotation features are still available for use.

Two additional metadata annotations have been added to support Ember Data Rest Adapter specific features: `[Sideload]` and `[AlternateName]`. By default, only the top level of an object graph is serialized to JSON for Ember Data. Any object references or collection references are serialized as arrays of IDs to be lazially loaded later. Adding the `[Sideload]` attribute to an object reference or collection will force any referenced objects to be serialized along with the root as a sideloaded collection. The `[AlternateName]` attribute is used for changing the type name communicated to Ember Data.

Adding the Ember Data Adapter to your Web API project is very easy.

1. Add `config.Formatters.Insert(0, new EmberDataMediaTypeFormatter());` to your Global.asax.cs file.
2. Declare your controllers as extending `EmberDataController<T>` where T is your model type.

Presently, this code only supports reading from Web API based services. Writing and creation will be added shortly.
