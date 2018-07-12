import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from '../models/Models';


@Component
export default class CharacterCreationComponent extends Vue {

    characterName: string = '';

    onClick() {
        console.log('Current character : ' + this.characterName);
        console.log('Current game : ' + this.$store.state.game);
        fetch(`http://localhost:53713/api/Character/${this.$store.state.game}/creation/${this.characterName}`, { method: 'post' })
            .then(data => console.log(data))
            .then(() => { this.$router.push({ name: 'details', params: { characterName: this.characterName } }) });            
    }

}