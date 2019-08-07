import { DataManipulation } from './data-manipulation';

describe('DataManipulation', () => {
    let dataManipulation;

    beforeEach(() => {
        dataManipulation = new DataManipulation();
    });

    describe('BuildName', () => {
        it('should return null name value if all values are null', () => {
            const firstName = null;
            const middleName = null;
            const lastName = null;
            const suffix = null;
            const businessName = null;
            const ownerName = null;

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, null, false)).toBeNull();
        });

        it('should return a blank name value if all values are blank', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('');
        });

        it('should return the business name when all value are blank expect businessName', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = 'ACME';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('ACME');
        });

        it('should return the business name when all value are null expect businessName', () => {
            const firstName = null;
            const middleName = null;
            const lastName = null;
            const suffix = null;
            const businessName = 'ACME';
            const ownerName = null;

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('ACME');
        });

        it('should return a name when only first and middle are filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom A');
        });

        it('should return a name when only first and suffix are filled in', () => {
            const firstName = 'Tom';
            const middleName = '';
            const lastName = '';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Jr., Tom');
        });

        it('should return a name when only first and last are filled in', () => {
            const firstName = 'Tom';
            const middleName = '';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith, Tom');
        });

        it('should return a name when only first, suffix and last are filled in', () => {
            const firstName = 'Tom';
            const middleName = '';
            const lastName = 'Smith';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr., Tom');
        });

        it('should return a name when only first, suffix and middle are filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = '';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Jr., Tom A');
        });

        it('should return a name when only middle name is filled in', () => {
            const firstName = '';
            const middleName = 'A';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('A');
        });

        it('should return a only a middle initial', () => {
            const firstName = '';
            const middleName = 'Alan';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('A');
        });

        it('should return a only a middle initial as part of a name', () => {
            const firstName = 'Tom';
            const middleName = 'Alan';
            const lastName = 'Smith';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr., Tom A');
        });

        it('should return a only a middle initial as part of a name without a suffix', () => {
            const firstName = 'Tom';
            const middleName = 'Alan';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith, Tom A');
        });

        it('should return a period after the suffix if its not there already', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = 'Jr';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Jr.');
        });

        it('should not return an extra period after the suffix if its there already', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Jr.');
        });

        it('should return a name when only last name is filled in', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = 'Smith';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith');
        });

        it('should return a name when only first name is filled in', () => {
            const firstName = 'Tom';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom');
        });

        it('should return a name when only last and suffix are filled in', () => {
            const firstName = '';
            const middleName = '';
            const lastName = 'Smith';
            const suffix = 'Jr';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr.');
        });

        it('should return a name when only last and middle are filled in', () => {
            const firstName = '';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith, A');
        });

        it('should return a name when only last, suffix and middle are filled in', () => {
            const firstName = '';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = 'Jr.';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr., A');
        });

        it('should return a name when only first, middle and last are filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith, Tom A');
        });

        it('should return a name when first, middle, suffix and last are filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = 'Jr';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr., Tom A');
        });

        it('should return a name when first, middle, suffix and last are filled in even if owner name is filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = 'Jr';
            const businessName = '';
            const ownerName = 'Tom Smith';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Smith Jr., Tom A');
        });

        it('should return a name when middle and suffix are filled in', () => {
            const firstName = '';
            const middleName = 'A';
            const lastName = '';
            const suffix = 'Jr';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Jr., A');
        });

        it('should return a name when first and middle are filled in', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom A');
        });


        it('should not return the Owner name if something else is filled in', () => {
            const firstName = 'Tom';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = 'Tom Smith';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom');
        });

        it('should only return the Owner name if nothing else is filled in with empty strings', () => {
            const firstName = '';
            const middleName = '';
            const lastName = '';
            const suffix = '';
            const businessName = '';
            const ownerName = 'Tom Smith';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom Smith');
        });

        it('should only return the Owner name if nothing else is filled in with nulls', () => {
            const firstName = null;
            const middleName = null;
            const lastName = null;
            const suffix = null;
            const businessName = null;
            const ownerName = 'Tom Smith';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, '', false)).toBe('Tom Smith');
        });

        it('should return a joint indictor when the add new fields feature is on and the account is a joint account', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, 'Y', true)).toBe('Smith, Tom A*');
        });

        it(`should return a joint indictor when the add new fields feature is on and the account is a joint account and
            the value is lower case`, () => {
                const firstName = 'Tom';
                const middleName = 'A';
                const lastName = 'Smith';
                const suffix = '';
                const businessName = '';
                const ownerName = '';

                expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                    businessName, ownerName, 'y', true)).toBe('Smith, Tom A*');
            });

        it('should not return a joint indictor when the add new fields feature is on and the account is a joint account', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, 'N', true)).toBe('Smith, Tom A');
        });

        it(`should not return a joint indictor when the add new fields feature is off even if the account is a joint account
            and the value is lower case`, () => {
                const firstName = 'Tom';
                const middleName = 'A';
                const lastName = 'Smith';
                const suffix = '';
                const businessName = '';
                const ownerName = '';

                expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                    businessName, ownerName, 'y', false)).toBe('Smith, Tom A');
            });

        it('should not return a joint indictor when the add new fields feature is off and the account is not joint', () => {
            const firstName = 'Tom';
            const middleName = 'A';
            const lastName = 'Smith';
            const suffix = '';
            const businessName = '';
            const ownerName = '';

            expect(dataManipulation.BuildName(firstName, middleName, lastName, suffix,
                businessName, ownerName, 'n', false)).toBe('Smith, Tom A');
        });

    });

});
