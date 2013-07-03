window.App = Ember.Application.create();

// Data models
App.Posts = DS.Model.extend({
    title: DS.attr('string')
});

App.Store = DS.Store.extend({
    revision: 12,
    adapter: 'DS.FixtureAdapter'
});

// Fixture data
App.Posts.FIXTURES = [
    {
        id: 1,
        title: "Fixture title 1"
    },
    {
        id: 2,
        title: "Fixture title 2"
    },
    {
        id: 3,
        title: "Fixture title 3"
    }
];

// Routing
App.Router.map(function () {
    this.resource('posts', { path: '/' });
    this.resource('post', { path: '/post/:post_id' });
});

App.PostsRoute = Ember.Route.extend({
    model: function() {
        return App.Posts.find();
    }
});

App.PostRoute = Ember.Route.extend({
    model: function (params) {
        return App.Posts.find(params.post_id);
    }
});

// Controllers
App.PostsController = Ember.ArrayController.extend({
    
});

App.PostController = Ember.ObjectController.extend({
    
});