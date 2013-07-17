window.App = Ember.Application.create();

// Data models
App.Post = DS.Model.extend({
    title: DS.attr('string'),
    comments: DS.hasMany('App.Comment')
});

App.Comment = DS.Model.extend({
    post: DS.belongsTo('App.Post'),
    body: DS.attr('string'),
});

DS.RESTAdapter.reopen({
    namespace: 'api'
});

//DS.RESTAdapter.configure("plurals", {
//    post: "posties"
//});

App.Store = DS.Store.extend({
    revision: 12,
    adapter: 'DS.RESTAdapter'
});

// Routing
App.Router.map(function () {
    this.resource('posts', { path: '/' });
    this.resource('post', { path: '/post/:post_id' });
});

App.PostsRoute = Ember.Route.extend({
    model: function() {
        return App.Post.find();
    }
});

App.PostRoute = Ember.Route.extend({
    model: function (params) {
        return App.Post.find(params.post_id);
    }
});

// Controllers
App.PostsController = Ember.ArrayController.extend({
    
});

App.PostController = Ember.ObjectController.extend({
    
});