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

App.Store = DS.Store.extend({
    revision: 12,
//    adapter: 'DS.FixtureAdapter'
});

// Fixture data
App.Post.FIXTURES = [
    {
        id: 1,
        title: "Fixture post 1",
        comments: [1, 2, 3]
    },
    {
        id: 2,
        title: "Fixture post 2",
        comments: [4]
    },
    {
        id: 3,
        title: "Fixture post 3",
        comments: [5, 6]
    }
];

App.Comment.FIXTURES = [
    {
        id: 1,
        body: "Fixture comment 1",
        post: [1]
    },
    {
        id: 2,
        body: "Fixture comment 2",
        post: [1]
    },
    {
        id: 3,
        body: "Fixture comment 3",
        post: [1]
    },
    {
        id: 4,
        body: "Fixture comment 4",
        post: [2]
    },
    {
        id: 5,
        body: "Fixture comment 5",
        post: [3]
    },
    {
        id: 6,
        body: "Fixture post 6",
        post: [3]
    }
];

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