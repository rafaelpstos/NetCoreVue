import './css/site.css';
import './css/custom.css';
import './css/font-awesome.css';
import 'bootstrap';
import Vue from 'vue';
import VueRouter from 'vue-router';
import * as a from './global'
Vue.use(VueRouter);


const routes = [
    { path: '/', component: require('./components/login/login.vue.html'), beforeEnter: requireAuth },
    { path: '/dashboard', component: require('./components/home/home.vue.html'), beforeEnter: requireAuth },
    { path: '/usuario', component: require('./components/usuario/usuario.vue.html'), beforeEnter: requireAuth },

    { path: '/produto', component: require('./components/produto/produto.vue.html'), beforeEnter: requireAuth },
    { path: '/produto/cadastrar', component: require('./components/produto/cadastrar.vue.html'), beforeEnter: requireAuth }
];

function requireAuth(to: any, from: any, next: any) {

    if (!localStorage.getItem("TOKEN")) {
        next({
            path: '/',
        })
    } else {
        next()
    }
}

new Vue({
    el: '#app-root',
    router: new VueRouter({ mode: 'history', routes: routes }),
    render: h => h(require('./components/app/app.vue.html'))
});
