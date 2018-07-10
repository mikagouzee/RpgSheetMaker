import './css/site.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
Vue.use(VueRouter);

const routes = [
    { path: '/', component: require('./components/home/home.vue.html') },
    { path: '/counter', component: require('./components/counter/counter.vue.html') },
    { path: '/fetchdata', component: require('./components/fetchdata/fetchdata.vue.html') },
    { path: '/characterlist', component: require('./components/characters/characterlist.vue.html') },
    { path: '/character/:characterName', name: 'details', component: require('./components/characters/characterDetail.vue.html'), props: true },
    { path: '/characterCreation', component: require('./components/characters/characterCreation.vue.html') },
    { path: '/characterUpdate', name: 'update', component: require('./components/characters/characterUpdate.vue.html'), props: {currentCharacter:false}}
];

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
