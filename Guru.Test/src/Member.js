export default class Member {
    
    constructor() {
        this.id = 0,
        this.email = '',
        this.createdDate = '',
        this.firstName = '',
        this.lastName = '',
        this.phone = '',
        this.webSite = ''
    }
    
    clone() {
        return Member.from(this);
    }

    /**
     * @param {Member} member
     */
    static from(member) {
        var clone = new Member();
        clone.id = member.id;
        clone.email = member.email;
        clone.createdDate = member.createdDate;
        clone.firstName = member.firstName;
        clone.lastName = member.lastName;
        clone.phone = member.phone;
        clone.webSite = member.webSite;

        return clone;
    }
}
