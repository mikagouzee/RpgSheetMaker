import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import Vuex from 'vuex';
import { Game } from '../ClientApp/components/models/Models';

Vue.use(Vuex);
Vue.use(VueRouter);


const store = new Vuex.Store({
    state: {
        count: 0,
        game: {
            name: 'Fallout',
            jobs:['mendiant', 'fighter', 'wanderer', 'merchant']
        }
    },
    mutations: {
        increment(state) {
            state.count++
        },

        selectGame(state, game) {
            state.game = game;
            console.log("from Store: " + state.game.name);
            console.log("With jobs : ");
            state.game.jobs.forEach(x => console.log(x));
        }
    }
})

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/characterlist', component: require('./components/characters/characterlist.vue.html') },
    { path: '/character/:characterName', name: 'details', component: require('./components/characters/characterDetail.vue.html'), props: true },
    { path: '/characterCreation', name: 'creation', component: require('./components/characters/characterCreation.vue.html') },
    { path: '/game', component:require('./components/game/gameSelection.vue.html')}
];



new Vue({
    el: '#app-root',
    store,
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
