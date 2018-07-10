﻿import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from './Models';


@Component
export default class CharacterCreationComponent extends Vue {

    characterName: string = '';

    onClick() {
        fetch('http://localhost:53713/api/FalloutCharacter/' + this.characterName, { method: 'post' })
            .then(data => console.log(data));

        this.$router.push({ name: 'details', params: { characterName: this.characterName } });            
    }

}