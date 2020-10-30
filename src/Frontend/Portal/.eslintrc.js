/* eslint-disable no-undef */
module.exports = {
	root: true,
	parser: "@typescript-eslint/parser",
	plugins: [
		"@typescript-eslint",
	],
	extends: [
		"eslint:recommended",
		"plugin:@typescript-eslint/recommended",
	],
	rules: {
		"eqeqeq": ["error", "always", { "null": "ignore" }],
		"no-console": ["error", { allow: ["warn", "error", "debug"] }],
		"@typescript-eslint/prefer-for-of": "off",
		"@typescript-eslint/no-namespace": "off",
		"@typescript-eslint/prefer-namespace-keyword": "off",
		"indent": "off",
		"@typescript-eslint/indent": ["error", "tab"],
		"@typescript-eslint/explicit-member-accessibility": "off",
		"camelcase": "off",
		"@typescript-eslint/naming-convention": [
			"error",
			{
				"selector": "default",
				"format": ["camelCase"]
			},
			{
				"selector": "parameter",
				"format": ["camelCase"],
				"leadingUnderscore": "allow"
			},
			{"selector": "interface",
				"format": ["PascalCase"],
				"custom": {
					"regex": "^I[A-Za-z]+",
					"match": true
				}
			}
		],
		"@typescript-eslint/no-explicit-any": ["error"],
		"quotes": ["error", "double"]
	}
};
