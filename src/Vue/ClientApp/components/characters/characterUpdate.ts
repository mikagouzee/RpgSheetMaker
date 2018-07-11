import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from './Models'; 

@Component
export default class CharacterUpdateComponent extends Vue {
    @Prop() currentCharacter: Character;

    Update() {
        console.log("Updating");
    }

}